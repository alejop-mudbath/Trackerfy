import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from "@angular/forms";
import { UsersRoutingModule } from "./users.routing-module";
import { AuthModule } from "../auth/auth.module";
let UsersModule = class UsersModule {
};
UsersModule = __decorate([
    NgModule({
        declarations: [RegisterComponent],
        imports: [
            CommonModule,
            FormsModule,
            UsersRoutingModule,
            AuthModule
        ],
        providers: []
    })
], UsersModule);
export { UsersModule };
//# sourceMappingURL=users.module.js.map