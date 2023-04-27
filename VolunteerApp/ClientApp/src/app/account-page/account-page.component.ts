import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthorizationService } from '../shared/services/authorization.service';

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
  isVerified: boolean = true;

  private userSub: Subscription;

  constructor(private authService: AuthorizationService) { }

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe(user => {
      this.userName = user.NickName;
      this.userType = user.Role;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }
}
