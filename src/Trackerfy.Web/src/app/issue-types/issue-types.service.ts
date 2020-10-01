import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IssueTypeInterface} from "./issue-type.interface";

@Injectable({
  providedIn: 'root'
})
export class IssueTypesService {

  private authApiURI: string = "http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  getIssueTypes() {
    return this.http.get<IssueTypeInterface[]>(this.authApiURI + '/issues/types')
  }
}
