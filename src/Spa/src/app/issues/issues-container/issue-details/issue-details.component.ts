import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {IssuesService} from '../../issues.service';
import {IssueInterface} from '../../shared/issue.interface';
import {UsersService} from '../../../users/users.service';
import {UserModel} from '../../../users/user.model';
import {WorkflowService} from '../../../workflow/workflow.service';
import {IssueStateModel} from '../../../workflow/issueState.model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-issue-details',
  templateUrl: './issue-details.component.html',
  styleUrls: ['./issue-details.component.sass']
})
export class IssueDetailsComponent implements OnInit {
  issueId: number;
  issue: IssueInterface = {} as IssueInterface;
  users: UserModel[];
  issueStates: IssueStateModel[];

  constructor(private route: ActivatedRoute, private issuesService: IssuesService,
              private usersService: UsersService,
              private workflowService: WorkflowService,
              private toastr: ToastrService) {

    this.route.params.subscribe(params => {
      this.issueId = params.issueId;
      this.getIssue();
    });

    usersService.getAll().subscribe(result => {
      this.users = result;
    });
    this.workflowService.getStates().subscribe(result => {
      this.issueStates = result;
    });
  }

  ngOnInit(): void {
  }

  getIssue(): void {
    this.issuesService.getIssueById(this.issueId).subscribe(result => {
      this.issue = result;
    });
  }

  updateState(issueState: IssueStateModel) {
    this.issuesService.updateState(this.issueId, issueState.id).subscribe(result => {
      this.toastr.success('Issue update successfully');
      this.issuesService.changeMessage('');
      this.getIssue();
    });
  }
}
