import {Injectable} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {AuthService} from './auth.service';
import {catchError, switchMap} from 'rxjs/operators';
import {environment} from '../../environments/environment';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {
  }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.auth.getTokenSilently.pipe(
      switchMap(token => {
        const tokenReq = req.clone({
          url: `${environment.apiUrl}/${req.url}`,
          setHeaders: {Authorization: `Bearer ${token}`}
        });
        return next.handle(tokenReq);
      }),
      catchError(err => throwError(err))
    );
  }
}

