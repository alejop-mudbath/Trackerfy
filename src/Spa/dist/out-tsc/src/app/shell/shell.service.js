import { __decorate } from "tslib";
import { ShellComponent } from './shell.component';
import { Injectable } from '@angular/core';
let Shell = class Shell {
    static childRoutes(routes) {
        return {
            path: '',
            component: ShellComponent,
            children: routes,
            // =canActivate: [AuthenticationGuard],
            // Reuse ShellComponent instance when navigating between child views
            data: { reuse: true }
        };
    }
};
Shell = __decorate([
    Injectable({
        providedIn: 'root'
    })
], Shell);
export { Shell };
//# sourceMappingURL=shell.service.js.map