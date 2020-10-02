import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let AuthGuard = class AuthGuard {
    constructor(authService) {
        this.authService = authService;
    }
    canActivate(route, state) {
        if (!this.authService.loggedIn) {
            this.authService.login();
            //this.router.navigate(['/']);
            return false;
        }
        return true;
    }
};
AuthGuard = __decorate([
    Injectable({
        providedIn: 'root'
    })
], AuthGuard);
export { AuthGuard };
//# sourceMappingURL=auth.guard.js.map