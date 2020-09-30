import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {Shell} from '../shell/shell.service';
import {IssueDetailsComponent} from "./issues-container/issue-details/issue-details.component";
import {IssuesListComponent} from "./issues-container/issues-list/issues-list.component";

const routes: Routes = [
  Shell.childRoutes([
    {path: '', redirectTo: '/issues-list', pathMatch: 'full'},
    {path: 'issues-list', component: IssuesListComponent,},
    {path: 'issue-detail/:issueId', component: IssueDetailsComponent,}
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class IssuesRoutingModule {
}
