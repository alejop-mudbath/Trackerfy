import { __decorate } from "tslib";
import { catchError, concatMap, shareReplay, tap } from "rxjs/operators";
import { BehaviorSubject, combineLatest, from, of, throwError } from "rxjs";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import createAuth0Client from "@auth0/auth0-spa-js";
window.global = window;
let AuthService = class AuthService {
    // Create a stream of logged in status to communicate throughout app
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.authApiURI = "http://localhost:5000/api";
        this.auth0Client$ = from(createAuth0Client({
            domain: environment.auth.domain,
            client_id: environment.auth.clientId,
            redirect_uri: environment.auth.redirect,
            audience: environment.auth.audience,
        })).pipe(shareReplay(1), // Every subscription receives the same shared value
        catchError(err => throwError(err)));
        this.isAuthenticated$ = this.auth0Client$.pipe(concatMap((client) => from(client.isAuthenticated())), tap(res => this.loggedIn = res));
        this.getTokenSilently = this.auth0Client$.pipe(concatMap((client) => from(client.getTokenSilently())));
        this.handleRedirectCallback$ = this.auth0Client$.pipe(concatMap((client) => from(client.handleRedirectCallback())));
        // Create subject and public observable of user profile data
        this.userProfileSubject$ = new BehaviorSubject(null);
        this.userProfile$ = this.userProfileSubject$.asObservable();
        // Create a local property for login status
        this.loggedIn = null;
    }
    getUser$(options) {
        return this.auth0Client$.pipe(concatMap((client) => from(client.getUser(options))), tap(user => this.userProfileSubject$.next(user)));
    }
    login(redirectPath = '/') {
        // A desired redirect path can be passed to login method
        // (e.g., from a route guard)
        // Ensure Auth0 client instance exists
        this.auth0Client$.subscribe((client) => {
            // Call method to log in
            client.loginWithRedirect({
                redirect_uri: environment.auth.redirect,
                appState: { target: redirectPath }
            });
        });
    }
    logout() {
        // Ensure Auth0 client instance exists
        this.auth0Client$.subscribe((client) => {
            // Call method to log out
            client.logout({
                client_id: environment.auth.clientId,
                returnTo: `${window.location.origin}`
            });
        });
    }
    register(userRegistration) {
        return this.http.post(this.authApiURI + '/users/register', userRegistration)
            .pipe(catchError(handlerError));
        function handlerError(error) {
            return throwError(error.error.error);
        }
    }
    get isLoggedIn() {
        // Check if current date is before token
        // expiration and user is signed in locally
        return this.loggedIn;
    }
    handleLoginCallback() {
        this.localAuthSetup();
        this.handleAuthCallback();
    }
    localAuthSetup() {
        // This should only be called on app initialization
        // Set up local authentication streams
        const checkAuth$ = this.isAuthenticated$.pipe(concatMap((loggedIn) => {
            if (loggedIn) {
                // If authenticated, get user and set in app
                // NOTE: you could pass options here if needed
                return this.getUser$();
            }
            console.log("loggedIn" + loggedIn);
            // If not authenticated, return stream that emits 'false'
            return of(loggedIn);
        }));
        checkAuth$.subscribe();
    }
    handleAuthCallback() {
        // Call when app reloads after user logs in with Auth0
        const params = window.location.search;
        if (params.includes('code=') && params.includes('state=')) {
            let targetRoute; // Path to redirect to after login processed
            const authComplete$ = this.handleRedirectCallback$.pipe(
            // Have client, now call method to handle auth callback redirect
            tap(cbRes => {
                // Get and set target redirect route from callback results
                targetRoute = cbRes.appState && cbRes.appState.target ? cbRes.appState.target : '/';
            }), concatMap(() => {
                // Redirect callback complete; get user and login status
                return combineLatest([
                    this.getUser$(),
                    this.isAuthenticated$
                ]);
            }));
            // Subscribe to authentication completion observable
            // Response will be an array of user and login status
            authComplete$.subscribe(([user, loggedIn]) => {
                // Redirect to target route after callback processing
                this.router.navigate([targetRoute]);
            });
        }
    }
};
AuthService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], AuthService);
export { AuthService };
//# sourceMappingURL=auth.service.js.map