import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

import { SignupData } from 'src/app/shared/models/classes/signup';
import { Login } from '../models/classes/login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  user = new BehaviorSubject<SignupData>(null);
  loginUser = new BehaviorSubject<Login>(null);
  
  constructor(private http: HttpClient, private router: Router) { }

  checkNickname(value: string) {
    return this.http.post<boolean>(environment.apiUrl+'/Nickname/'+value, value);
  }

  checkPhoneNumber(value: string){
    return this.http.post<boolean>(environment.apiUrl+'/PhoneNumber/'+value, value);
  }

  signUp(userData: SignupData){
    return this.http.post<any>(environment.apiUrl+'/User', userData);
  }
  
  login(userData: Login) {
    return this.http.post<Login>(environment.apiUrl + '/Auth/token', userData);
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/'])
  }
}
