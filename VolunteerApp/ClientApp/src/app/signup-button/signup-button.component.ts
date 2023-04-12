import { Component } from '@angular/core';

@Component({
  selector: 'app-signup-button',
  template: `<a routerLink="/authorization-page" class="signup">Зареєструватися</a>`,
  styleUrls: ['./signup-button.component.css'],
})
export class SignUpBtnComponent {}
