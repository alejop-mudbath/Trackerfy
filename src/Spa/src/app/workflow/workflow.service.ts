import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {switchMap} from 'rxjs/operators';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '../auth/auth.service';
import {IssueStateModel} from './issueState.model';

@Injectable({
  providedIn: 'root'
})
export class WorkflowService {
  constructor(private http: HttpClient, private auth: AuthService) {
  }

  getStates(): Observable<IssueStateModel[]> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token =>
        this.http.get<IssueStateModel[]>(`${environment.apiUrl}/workflow/states`, {
          headers: {Authorization: `Bearer ${token}`}
        }))
    );
  }
}
