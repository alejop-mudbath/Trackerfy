import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { Shell } from '../shell/shell.service';
const routes = [
    Shell.childRoutes([
        {
            path: 'register', component: RegisterComponent
        }
    ])
];
let UsersRoutingModule = class UsersRoutingModule {
};
UsersRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
        providers: []
    })
], UsersRoutingModule);
export { UsersRoutingModule };
//# sourceMappingURL=users.routing-module.js.map