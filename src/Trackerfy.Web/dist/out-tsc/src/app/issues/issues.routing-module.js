import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import { IssueDetailsComponent } from "./issues-container/issue-details/issue-details.component";
import { IssuesListComponent } from "./issues-container/issues-list/issues-list.component";
import { IssuesContainerComponent } from "./issues-container/issues-container.component";
import { AuthGuard } from "../auth/auth.guard";
const routes = [
    Shell.childRoutes([
        { path: '', redirectTo: '/issues', pathMatch: 'full' },
        {
            path: 'issues', component: IssuesContainerComponent,
            canActivate: [
                AuthGuard
            ],
            children: [
                { path: '', redirectTo: '/issues/issues-list', pathMatch: 'full' },
                { path: 'issues-list', component: IssuesListComponent, },
                { path: 'issues-list/:stateId', component: IssuesListComponent, },
                { path: 'issue-detail/:issueId', component: IssueDetailsComponent }
            ]
        },
    ])
];
let IssuesRoutingModule = class IssuesRoutingModule {
};
IssuesRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
        providers: []
    })
], IssuesRoutingModule);
export { IssuesRoutingModule };
//# sourceMappingURL=issues.routing-module.js.map