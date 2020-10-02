import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateIssueModel} from "./shared/createIssueModel";
import {IssueInterface} from "./shared/issue.interface";
import {AuthService} from "../auth/auth.service";
import {Observable} from "rxjs";
import {switchMap} from "rxjs/operators";
import {IssuesStateStatisticModel} from "./shared/issuesStateStatistic.model";
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IssuesService {

  constructor(private http: HttpClient, private auth: AuthService, ) {
  }

  getAllIssues(): Observable<IssueInterface[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueInterface[]>(`${environment.apiUrl}/issues`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  getIssuesStatistics(): Observable<IssuesStateStatisticModel[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssuesStateStatisticModel[]>(`${environment.apiUrl}/issues/statistics`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  getIssuesByState(stateId): Observable<IssueInterface[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueInterface[]>(`${environment.apiUrl}/issues/state/${stateId}`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  create(createIssue: CreateIssueModel){
    return this.http.post(`${environment.apiUrl}/issues`, createIssue);
  }

  getIssueById(issueId: number): Observable<IssueInterface> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
          fetch(`${environment.apiUrl}/issues/${issueId}`, {
            method: 'GET',
            headers: {
              Authorization: `Bearer ${token}`
            }
          }).then(result => result.json())

      ));
  }
}
