import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { AuthorizationService } from '../shared/services/authorization.service';
import { UserService } from '../shared/services/user.service';
import { SignupData } from '../shared/models/classes/signup';
import { Login } from '../shared/models/classes/login';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit, OnDestroy {
  chatOpened = false;
  isExpanded: boolean = false;
  userName: string = '';
  userType: string = '';
  isVerified: boolean = false;

  private userSignupSub: Subscription;
  private userLoginSub: Subscription;

  constructor(
    private authService: AuthorizationService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userSignupSub = this.authService.user.subscribe((user: SignupData) => {
      this.userName = user.NickName;
      this.userType = user.Role;
    });

    this.userLoginSub = this.authService.loginUser.subscribe((data: Login) => {
      this.userName = data.NickName;
    });

    // this.userService.fetchUserData(this.userName).subscribe(data => {
    //   this.userType = data.Role;
    // });
  }

  ngOnDestroy(): void {
    this.userSignupSub.unsubscribe();
    this.userLoginSub.unsubscribe();
  }
}
