import {Component, OnInit} from '@angular/core';
import {IssuesService} from "../../issues.service";
import {IssueInterface} from "../../shared/issue.interface";

@Component({
  selector: 'app-issues-list',
  templateUrl: './issues-list.component.html',
  styleUrls: ['./issues-list.component.sass']
})
export class IssuesListComponent implements OnInit {
  issues: IssueInterface[] = [];

  constructor(private issuesServices: IssuesService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  async getAll() {
    this.issuesServices.getAllIssues().subscribe(result => {
      this.issues = result;
    });
  }

}
