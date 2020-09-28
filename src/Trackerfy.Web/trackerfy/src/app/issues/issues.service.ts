import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IssueInterface} from "./issue.interface";

@Injectable({
  providedIn: 'root'
})
export class IssuesService {
  private authApiURI: string = "http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  getAllIssues() {
    return this.http.get<IssueInterface[]>(this.authApiURI + '/issues')
  }
}
