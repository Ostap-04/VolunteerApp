import { Component, OnDestroy } from '@angular/core';
import { OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { AuthorizationService } from '../shared/services/authorization.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit, OnDestroy {
  isMenuOpen: boolean = false;
  authenticatedUserMode: boolean = false;
  logedInUserMode: boolean = false;
  
  private userSignupSub: Subscription;
  private userLoginSub: Subscription;

  constructor(private authService: AuthorizationService) {}

  ngOnInit(): void {
    this.userSignupSub = this.authService.user.subscribe(user => {
      this.authenticatedUserMode = !!user;
    });

    this.userLoginSub = this.authService.loginUser.subscribe(user => {
      this.logedInUserMode = !!user;
    });
  }

  ngOnDestroy(): void {
    this.userSignupSub.unsubscribe();
    this.userLoginSub.unsubscribe();
  }

  onLogout() {
    this.authService.logout();
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
