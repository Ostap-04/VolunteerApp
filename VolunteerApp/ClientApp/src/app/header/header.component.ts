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
  private userSub: Subscription;

  constructor(private authService: AuthorizationService) {}

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe(user => {
      this.authenticatedUserMode = !!user;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }

  onLogout() {
    this.authService.logout();
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
