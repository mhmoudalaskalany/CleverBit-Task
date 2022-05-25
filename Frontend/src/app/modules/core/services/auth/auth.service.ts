import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../http/http.service';
@Injectable({
  providedIn: 'root'
})

/**
 * Auth Services
 * the main service for authentications
 */
export class AuthService extends HttpService {

  get baseUrl(): string {
    return 'Accounts/'
  }

  login(loginModel: any): Observable<any> {
    return this.postReq('Login', loginModel);
  }



  logout() {
    localStorage.clear();
    sessionStorage.clear();
  }



}
