import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserValidators } from '../user-validators';
import { AuthorizationService } from '../../shared/services/authorization.service';
import { SignupData } from 'src/app/shared/models/classes/signup';

@Component({
  selector: 'app-authorization-page',
  templateUrl: './authorization-page.component.html',
  styleUrls: ['./authorization-page.component.css']
})
export class AuthorizationPageComponent implements OnInit {
  constructor( 
    private authService: AuthorizationService,
    private router: Router
  ) {}

  confirmStep: boolean = false;
  showPassword: boolean = false;
  showPasswordTips: boolean = false;
  isLoading: boolean = false;
  isAgreed: boolean = true;

  phoneInputMask: any[] = ['+','(', '3','8','0', ')', ' ', /\d/, /\d/, '-', /\d/, /\d/, /\d/, '-', /\d/, /\d/, '-', /\d/, /\d/];
  roles: string[] = ['Військовий', 'Волонтер'];

  signupForm: FormGroup = new FormGroup(
    { 
      'nickname': new FormControl(null, [Validators.required], UserValidators.isUniqueNickName(this.authService)),
      'surname': new FormControl(null, [Validators.required]),
      'name': new FormControl(null, [Validators.required]),
      'fathername': new FormControl(null, [Validators.required]),
      'phone': new FormControl(null, [Validators.required, UserValidators.patternValidator(
        new RegExp(
          this.phoneInputMask.map((char) => {
            if (char instanceof RegExp) {
              return char.toString().slice(1, -1);
            } else {
              return char.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
            }
          }).join('')
        ), 
        {invalidPhone: true}
      )], UserValidators.isUniquePhone(this.authService)),
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(
        null, 
        [
          Validators.required,
          Validators.minLength(8),
          UserValidators.patternValidator(new RegExp("(?=.*[0-9])"), {
            requieresDigits: true
          }),
          UserValidators.patternValidator(new RegExp("(?=.*[A-Z])"), {
            requieresUppercase: true
          }),
          UserValidators.patternValidator(new RegExp("(?=.*[a-z])"), {
            requieresLowercase: true
          }),
          UserValidators.patternValidator(new RegExp("(?=.*[$@^!%*?&])"), {
            requieresSpecialChars: true
          })
        ]
      ),
      'confirmPassword': new FormControl(null, [Validators.required, Validators.minLength(8)]),
      'role': new FormControl("Військовий", [Validators.required]),
      'confirmationFile': new FormControl(null, [Validators.required, UserValidators.requiredFileType(["png", "jpg", "pdf"])])  
    },
    {
      validators: UserValidators.matchValidator
    }
  );

  ngOnInit(): void {
    window.scrollTo({
      top: 0
    });
  }

  handleUserData() {
    if(this.signupForm.get("password").errors == null) {
      this.confirmStep = true;   
    }else{
      this.showPasswordTips = true;
    }
  }
  
  get passwordErrors() {
    return this.signupForm.get('password').errors ? Object.keys(this.signupForm.get('password').errors) : [];
  }

  goToTermsOfUse(){}

  onSubmit() {
    if(this.signupForm.valid){
      const signUpData = new SignupData(
        this.signupForm.value.nickname,
        this.signupForm.value.surname,
        this.signupForm.value.name,
        this.signupForm.value.fathername,
        this.signupForm.value.phone,
        this.signupForm.value.email,
        this.signupForm.value.password,
        this.signupForm.value.role//,
        //this.signupForm.value.confirmData
      );
      this.isLoading = true;      
      this.authService.signUp(signUpData).subscribe(
        {
          next: (result) => {
            this.isLoading = false;
            this.authService.user.next(signUpData);
            this.router.navigate(['/account-page']);
          },
          error: (error) => {
            this.isLoading = false;
          },
        }
      );
      this.signupForm.reset();
    }
  }
}
