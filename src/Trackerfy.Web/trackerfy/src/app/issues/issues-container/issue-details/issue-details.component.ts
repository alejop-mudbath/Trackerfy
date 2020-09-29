import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {IssuesService} from "../../issues.service";
import {IssueInterface} from "../../shared/issue.interface";

@Component({
  selector: 'app-issue-details',
  templateUrl: './issue-details.component.html',
  styleUrls: ['./issue-details.component.sass']
})
export class IssueDetailsComponent implements OnInit {
  issueId: number;
  issue: IssueInterface;

  constructor(private route: ActivatedRoute, private issuesService: IssuesService) {

    this.route.params.subscribe(params => {
      this.issueId = params["issueId"];
      this.getIssue();
    });

  }

  ngOnInit(): void {
  }

  getIssue(){
    this.issuesService.getIssueById(this.issueId).subscribe(result=>{
      this.issue = result;
    })
  }

}
