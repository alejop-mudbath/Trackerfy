import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateIssueModel} from "./shared/createIssueModel";
import {IssueInterface} from "./shared/issue.interface";
import {AuthService} from "../auth/auth.service";
import {Observable} from "rxjs";
import {switchMap} from "rxjs/operators";
import {IssuesStateStatisticModel} from "./issuesStateStatistic.model";

@Injectable({
  providedIn: 'root'
})
export class IssuesService {
  private authApiURI: string = "http://localhost:5000/api";

  constructor(private http: HttpClient, private auth: AuthService) {
  }

  getAllIssues(): Observable<IssueInterface[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueInterface[]>(`${this.authApiURI}/issues`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  getIssuesStatistics(): Observable<IssuesStateStatisticModel[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueInterface[]>(`${this.authApiURI}/issues/statistics`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  getIssuesByState(stateId): Observable<IssueInterface[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueInterface[]>(`${this.authApiURI}/issues/state/${stateId}`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }

  create(createIssue: CreateIssueModel): Observable<Object> {
    return this.http.post(`${this.authApiURI}/issues`, createIssue)
  }

  getIssueById(issueId: number): Observable<IssueInterface> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
          fetch(`${this.authApiURI}/issues/${issueId}`, {
            method: 'GET',
            headers: {
              Authorization: `Bearer ${token}`
            }
          }).then(result => result.json())

      ));
  }
}
