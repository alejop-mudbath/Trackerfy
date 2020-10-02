import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthCallbackComponent } from "./auth-callback/auth-callback.component";
import { AuthService } from "./auth.service";
let AuthModule = class AuthModule {
};
AuthModule = __decorate([
    NgModule({
        declarations: [AuthCallbackComponent],
        imports: [
            CommonModule
        ],
        providers: [AuthService]
    })
], AuthModule);
export { AuthModule };
//# sourceMappingURL=auth.module.js.map