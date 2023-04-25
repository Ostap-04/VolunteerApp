import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

import { SignupData } from 'src/app/shared/models/classes/signup';
import { Login } from '../models/classes/login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  user = new Subject<SignupData>();
  loginUser = new Subject<Login>();
  constructor(private http: HttpClient, private router: Router) { }

  checkNickname(value: string) {
    return this.http.post<boolean>(environment.apiUrl + '/User', { userNickname: value });
  }

  checkPhoneNumber(value: string) {
    return this.http.post<boolean>(environment.apiUrl + '/User', { userPhone: value });
  }

  signUp(userData: SignupData) {
    return this.http.post<SignupData>(environment.apiUrl + '/User', userData);
  }

  login(userData: Login) {
    return this.http.post<Login>(environment.apiUrl + '/User', userData);
  }
  logout() {
    this.user.next(null);
    this.router.navigate(['/home-page'])
  }
}
