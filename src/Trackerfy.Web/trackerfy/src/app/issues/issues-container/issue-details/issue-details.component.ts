import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {IssuesService} from "../../issues.service";
import {IssueInterface} from "../../shared/issue.interface";
import {UsersService} from "../../../users/users.service";
import {UserModel} from "../../../users/user.model";

@Component({
  selector: 'app-issue-details',
  templateUrl: './issue-details.component.html',
  styleUrls: ['./issue-details.component.sass']
})
export class IssueDetailsComponent implements OnInit {
  issueId: number;
  issue: IssueInterface = {} as IssueInterface;
  users: UserModel[]

  constructor(private route: ActivatedRoute, private issuesService: IssuesService, private usersService: UsersService) {

    this.route.params.subscribe(params => {
      this.issueId = params["issueId"];
      this.getIssue();
    });

    usersService.getAll().subscribe(result => {
      this.users = result;
    });
  }

  ngOnInit(): void {
  }

  getIssue() {
    this.issuesService.getIssueById(this.issueId).subscribe(result => {
      this.issue = result;
    })
  }

}
