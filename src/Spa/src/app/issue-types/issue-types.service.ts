import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IssueTypeInterface} from './issue-type.interface';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IssueTypesService {

  constructor(private http: HttpClient) {
  }

  getIssueTypes(): Observable<IssueTypeInterface[]> {
    return this.http.get<IssueTypeInterface[]>('/issues/types');
  }
}
