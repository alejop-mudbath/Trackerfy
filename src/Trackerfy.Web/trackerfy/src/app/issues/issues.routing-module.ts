import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {Shell} from '../shell/shell.service';
import {IssuesContainerComponent} from "./issues-container/issues-container.component";
import {IssueDetailsComponent} from "./issues-container/issue-details/issue-details.component";
import {IssuesListComponent} from "./issues-container/issues-list/issues-list.component";

const routes: Routes = [
  Shell.childRoutes([
    {
      path: 'issues', component: IssuesContainerComponent,
      children: [
        {path: 'issues-list', component: IssuesListComponent,},
        {path: 'issue-detail/:issueId', component: IssueDetailsComponent,}
      ]
    },
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class IssuesRoutingModule {
}
