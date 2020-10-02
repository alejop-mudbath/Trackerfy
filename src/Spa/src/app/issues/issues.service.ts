import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CreateIssueModel} from './shared/createIssueModel';
import {IssueInterface} from './shared/issue.interface';
import {BehaviorSubject, Observable} from 'rxjs';
import {IssuesStateStatisticModel} from './shared/issuesStateStatistic.model';

@Injectable({
  providedIn: 'root'
})
export class IssuesService {
  private issuesSource = new BehaviorSubject('default message');
  issues = this.issuesSource.asObservable();

  constructor(private http: HttpClient) {
  }

  changeMessage(message: string): void {
    this.issuesSource.next(message);
  }

  getAllIssues(): Observable<IssueInterface[]> {
    return this.http.get<IssueInterface[]>(`issues`);
  }

  getIssuesStatistics(): Observable<IssuesStateStatisticModel[]> {
    return this.http.get<IssuesStateStatisticModel[]>(`issues/statistics`);
  }

  getIssuesByState(stateId): Observable<IssueInterface[]> {
    return this.http.get<IssueInterface[]>(`issues/state/${stateId}`);
  }

  create(createIssue: CreateIssueModel) {
    return this.http.post(`issues`, createIssue);
  }

  updateState(issudId, issueStateId) {
    return this.http.put(`issues/${issudId}/state`, {issueStateId});
  }

  getIssueById(issueId: number): Observable<IssueInterface> {
    return this.http.get<IssueInterface>(`issues/${issueId}`);
  }
}
