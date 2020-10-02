import {Component, OnInit} from '@angular/core';
import {IssuesService} from "../../issues.service";
import {IssueInterface} from "../../shared/issue.interface";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-issues-list',
  templateUrl: './issues-list.component.html',
  styleUrls: ['./issues-list.component.sass']
})
export class IssuesListComponent implements OnInit {
  issues: IssueInterface[] = [];

  constructor(private issuesServices: IssuesService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      const stateId = params["stateId"];
      this.getIssues(stateId);
    });
  }

  ngOnInit(): void {

  }

  async getIssues(statetId) {
    let issues = this.issuesServices.getAllIssues();

    if (statetId)
      issues = this.issuesServices.getIssuesByState(statetId);

    issues.subscribe(result => {
      this.issues = result;
    });
  }

}
