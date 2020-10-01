import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ShellComponent } from './shell.component';
import { HeaderComponent } from './header/header.component';
import { IssuesModule } from "../issues/issues.module";
let ShellModule = class ShellModule {
};
ShellModule = __decorate([
    NgModule({
        imports: [
            CommonModule,
            RouterModule,
            IssuesModule
        ],
        declarations: [ShellComponent, HeaderComponent]
    })
], ShellModule);
export { ShellModule };
//# sourceMappingURL=shell.module.js.map