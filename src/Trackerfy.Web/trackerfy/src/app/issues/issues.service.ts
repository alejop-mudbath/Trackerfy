import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateIssueModel} from "./shared/createIssueModel";
import {IssueInterface} from "./shared/issue.interface";
import {AuthService} from "../auth/auth.service";
import {from, Observable, Subject} from "rxjs";
import {concatMap, map, switchMap, tap} from "rxjs/operators";
import Auth0Client from "@auth0/auth0-spa-js/dist/typings/Auth0Client";

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
        // this.http.get<IssueInterface>(`${this.authApiURI}/issues/${issueId}`, {
        //   headers: {
        //     "Authorization": `Bearer ${token}`
        //   }
        // }))
      ));
  }
}
