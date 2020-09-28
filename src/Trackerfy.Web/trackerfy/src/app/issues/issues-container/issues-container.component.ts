import { Component, OnInit } from '@angular/core';
import {IssuesListComponent} from "./issues-list/issues-list.component";

@Component({
  selector: 'app-issues-container',
  templateUrl: './issues-container.component.html',
  styleUrls: ['./issues-container.component.sass']
})
export class IssuesContainerComponent implements OnInit {

  constructor(private comp: IssuesListComponent) { }

  ngOnInit(): void {
  }

  loadIssues() {
    this.comp.ngOnInit();
  }
}
