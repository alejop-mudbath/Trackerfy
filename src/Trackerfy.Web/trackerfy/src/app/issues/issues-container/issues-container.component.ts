import {Component, OnInit} from '@angular/core';
import {IssuesService} from "../issues.service";
import {IssuesStateStatisticModel} from "../shared/issuesStateStatistic.model";

@Component({
  selector: 'app-issues-container',
  templateUrl: './issues-container.component.html',
  styleUrls: ['./issues-container.component.sass']
})
export class IssuesContainerComponent implements OnInit {
  issueStatistics: IssuesStateStatisticModel[] = [];

  constructor(private issuesService: IssuesService) {
  }

  ngOnInit(): void {
    this.issuesService.getIssuesStatistics().subscribe(
      result => this.issueStatistics = result
    )
  }

}
