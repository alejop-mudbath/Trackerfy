import { __decorate } from "tslib";
import { Component } from '@angular/core';
let AuthCallbackComponent = class AuthCallbackComponent {
    constructor(auth) {
        this.auth = auth;
    }
    ngOnInit() {
        this.auth.handleLoginCallback();
    }
};
AuthCallbackComponent = __decorate([
    Component({
        selector: 'app-auth-callback',
        templateUrl: './auth-callback.component.html',
        styleUrls: ['./auth-callback.component.sass']
    })
], AuthCallbackComponent);
export { AuthCallbackComponent };
//# sourceMappingURL=auth-callback.component.js.map