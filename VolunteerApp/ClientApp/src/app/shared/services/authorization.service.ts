import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SignupData } from 'src/app/shared/models/classes/signup';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  constructor(private http: HttpClient) {}

  checkNickname(value: string){
    return this.http.post<boolean>(environment.apiUrl+'/User', {userNickname: value});
  }

  checkPhoneNumber(value: string){
    return this.http.post<boolean>(environment.apiUrl+'/User',{userPhone: value});
  }

  signUp(userData: SignupData){
    return this.http.post<SignupData>(environment.apiUrl+'/User', userData);    
  }
}
