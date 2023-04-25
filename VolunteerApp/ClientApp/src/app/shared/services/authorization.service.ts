import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

import { SignupData } from 'src/app/shared/models/classes/signup';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  user = new Subject<SignupData>();
  
  constructor(private http: HttpClient, private router: Router) {}

  // checkNickname(value: string) {
  //   return this.http.post<{[key: string]: string}>(environment.apiUrl+'/User', {NickName: value});
  // }

  // checkPhoneNumber(value: string){
  //   return this.http.post<{[key: string]: string}>(environment.apiUrl+'/User',{Phone_Number: value});
  // }

  signUp(userData: SignupData){
    return this.http.post<{[key: string]: any}>(environment.apiUrl+'/User', userData);    
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/home-page'])
  }
}