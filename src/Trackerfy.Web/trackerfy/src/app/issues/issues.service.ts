import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateIssueModel} from "./shared/createIssueModel";
import {IssueInterface} from "./shared/issue.interface";

@Injectable({
  providedIn: 'root'
})
export class IssuesService {
  private authApiURI: string = "http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  getAllIssues() {
    return this.http.get<IssueInterface[]>(`${this.authApiURI}/issues`)
  }

  create(createIssue: CreateIssueModel) {
    return this.http.post(`${this.authApiURI}/issues`, createIssue)
  }

  getIssueById(issueId: number) {
    return this.http.get<IssueInterface>(`${this.authApiURI}/issues/${issueId}`)
  }
}
