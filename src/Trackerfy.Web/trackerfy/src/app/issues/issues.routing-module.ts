import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import {IssuesContainerComponent} from "./issues-container/issues-container.component";

const routes: Routes = [
Shell.childRoutes([
    { path: 'issues', component: IssuesContainerComponent },
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class IssuesRoutingModule { }
