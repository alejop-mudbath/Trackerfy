import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {IssuesListComponent} from "./issues-container/issues-list/issues-list.component";
import {IssuesService} from "./issues.service";
import {IssuesRoutingModule} from "./issues.routing-module";
import {IssuesContainerComponent} from './issues-container/issues-container.component';
import {IssuesContentComponent} from './issues-container/issues-content/issues-content.component';


@NgModule({
  declarations: [IssuesContainerComponent, IssuesContentComponent, IssuesListComponent,],
  imports: [
    CommonModule,
    IssuesRoutingModule
  ],
  providers: [IssuesService],
  bootstrap: [IssuesContainerComponent]
})
export class IssuesModule {
}
