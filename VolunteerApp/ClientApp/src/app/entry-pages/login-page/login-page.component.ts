import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthorizationService } from 'src/app/shared/services/authorization.service';
import { Login } from 'src/app/shared/models/classes/login';
import { Router } from '@angular/router';
import { SocialAuthService } from "@abacritt/angularx-social-login";
import { FacebookLoginProvider } from "@abacritt/angularx-social-login";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})

export class LoginPageComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({
    'nickname': new FormControl(null, Validators.required),
    'password': new FormControl(null, Validators.required)
  })

  value = '';
  hide = true;
  user: any;
  loggedIn: any;
  isInvalid: boolean = false;

  constructor(
    private authService: AuthorizationService,
    private authServiceSocial: SocialAuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.authServiceSocial.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const loginData = new Login(
        this.loginForm.value.nickname,
        this.loginForm.value.password,
      );   
      this.authService.login(loginData).subscribe(
        {
          next: (result) => {
            this.isInvalid = false;
            this.authService.loginUser.next(loginData);
            this.router.navigate(['/account-page']);
          },
          error: (error) => {
            console.log(error);
            this.isInvalid = true;
          },
        }
      );
      this.loginForm.reset();
    }
  }

  signInWithFB(): void {
    this.authServiceSocial.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.authServiceSocial.signOut();
  }
}