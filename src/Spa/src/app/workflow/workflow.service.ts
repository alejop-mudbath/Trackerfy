import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {IssueStateModel} from './issueState.model';

@Injectable({
  providedIn: 'root'
})
export class WorkflowService {
  constructor(private http: HttpClient) {
  }

  getStates(): Observable<IssueStateModel[]> {
    return this.http.get<IssueStateModel[]>(`workflow/states`);
  }
}
