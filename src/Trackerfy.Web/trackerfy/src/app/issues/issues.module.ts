import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {IssuesListComponent} from "./issues-container/issues-list/issues-list.component";
import {IssuesService} from "./issues.service";
import {IssuesRoutingModule} from "./issues.routing-module";
import {ActionsComponent} from './issues-container/actions/actions.component';
import {IssuesContainerComponent} from './issues-container/issues-container.component';
import {IssuesContentComponent} from './issues-container/issues-content/issues-content.component';
import {CreateIssueComponent} from './create-issue/create-issue.component';
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {IssueTypesModule} from "../issue-types/issue-types.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [IssuesContainerComponent, IssuesContentComponent, IssuesListComponent,
    ActionsComponent, CreateIssueComponent,],
  imports: [
    CommonModule,
    IssuesRoutingModule,
    NgbModule,
    IssueTypesModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [IssuesService],
  bootstrap: [IssuesContainerComponent]
})
export class IssuesModule {
}
