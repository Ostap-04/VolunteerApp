import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  fetchUserData(nickName: string){
    return this.http.get<any>(environment.apiUrl + '/User/' + nickName);
  }

}
