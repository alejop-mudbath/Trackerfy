import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IssueTypeInterface} from "./issue-type.interface";
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IssueTypesService {

  constructor(private http: HttpClient) { }

  getIssueTypes() {
    return this.http.get<IssueTypeInterface[]>(environment.apiUrl + '/issues/types');
  }
}
