import {HttpClient} from "@angular/common/http";
import {catchError} from "rxjs/operators";
import {throwError} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private authApiURI: string = "http://localhost:5000/api";

  constructor(private http: HttpClient) {
  }

  register(userRegistration: any) {
    return this.http.post(this.authApiURI + '/users/register', userRegistration)
      .pipe(catchError(handlerError));

    function handlerError(error) {
      return throwError(error.error.error);
    }
  }
}
