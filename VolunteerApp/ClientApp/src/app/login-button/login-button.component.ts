import { Component } from '@angular/core';

@Component({
  selector: 'app-login-button',
  template: `<a routerLink="/login-page" class="login">Увійти</a>`,
  styleUrls: ['./login-button.component.css'],
})
export class LoginBtnComponent {}
