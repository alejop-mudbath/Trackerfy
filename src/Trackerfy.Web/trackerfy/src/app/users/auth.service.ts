import {HttpClient} from "@angular/common/http";
import {catchError} from "rxjs/operators";
import * as auth0 from 'auth0-js';
import {throwError} from "rxjs";
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Router} from "@angular/router";

(window as any).global = window;

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private authApiURI: string = "http://localhost:5000/api";

  auth0 = new auth0.WebAuth({
    clientID: environment.auth.clientId,
    domain: environment.auth.domain,
    responseType: 'token',
    redirectUri: environment.auth.redirect,
    scope: environment.auth.scope
  });
  // Store authentication data
  expiresAt: number;
  userProfile: any;
  accessToken: string;
  authenticated: boolean;

  constructor(private http: HttpClient, private router: Router) {
    this.getToken();
  }

  register(userRegistration: any) {
    return this.http.post(this.authApiURI + '/users/register', userRegistration)
      .pipe(catchError(handlerError));

    function handlerError(error) {
      return throwError(error.error.error);
    }
  }

  login() {
    //auth0 modal authorization
    this.auth0.authorize();
  }

  handleLoginCallback() {
    // When Auth0 hash parsed, get profile
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken) {
        window.location.hash = '';
        this.getUserInfo(authResult);
      } else if (err) {
        console.error(`Error: ${err.error}`);
      }
      this.router.navigate(['/']);
    });
  }

  getToken() {
    this.auth0.checkSession({}, (err, authResult) => {
      if (authResult && authResult.accessToken) {
        this.getUserInfo(authResult);
      }
    });
  }

  getUserInfo(authResult) {
    // Use access token to retrieve user's profile and set session
    this.auth0.client.userInfo(authResult.accessToken, (err, profile) => {
      if (profile) {
        this._setSession(authResult, profile);
      }
    });
  }

  private _setSession(authResult, profile) {
    // Save authentication data and update login status subject
    this.expiresAt = authResult.expiresIn * 1000 + Date.now();
    this.accessToken = authResult.accessToken;
    this.userProfile = profile;
    console.log(this.userProfile)
    this.authenticated = true;
  }

  logout() {
    // Log out of Auth0 session
    // Ensure that returnTo URL is specified in Auth0
    // Application settings for Allowed Logout URLs
    this.auth0.logout({
      returnTo: environment.auth.appUrl,
      clientID: environment.auth.clientId
    });
  }

  get isLoggedIn(): boolean {
    // Check if current date is before token
    // expiration and user is signed in locally
    return Date.now() < this.expiresAt && this.authenticated;
  }
}
