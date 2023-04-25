import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { environment } from 'src/environments/environment';
import { UserValidators } from '../user-validators';
import { AuthorizationService } from '../../shared/services/authorization.service';
import { SignupData } from 'src/app/shared/models/classes/signup';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-authorization-page',
  templateUrl: './authorization-page.component.html',
  styleUrls: ['./authorization-page.component.css']
})
export class AuthorizationPageComponent implements OnInit {
  constructor(private http: HttpClient, 
    private authService: AuthorizationService,
    private router: Router) {}

  confirmStep: boolean = false;
  showPassword: boolean = false;
  showPasswordTips: boolean = false;
  isLoading: boolean = false;
  isAgreed: boolean = true;

  working: boolean = false;
  uploadFile: File | null;
  uploadFileLabel: string | undefined = "Оберіть зображення щоб завнтажити"; 
  uploadProgress: number;
  uploadUrl: string;

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
      //'confirmData': new FormControl(null, Validators.required)
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
      console.log('errors');
    }
  }
  
  get passwordErrors() {
    return this.signupForm.get('password').errors ? Object.keys(this.signupForm.get('password').errors) : [];
  }

  //handleFileInput(files: FileList) {
  //  if(files.length) {
  //    this.uploadFile = files.item(0);
  //    this.uploadFileLabel = this.uploadFile?.name;
  //  }
  //}

  //upload() {
  //  if (!this.uploadFile) {
  //    alert('Choose a file to upload first');
  //    return;
  //  }
    
  //  const formData = new FormData();
  //  formData.append(this.uploadFile.name, this.uploadFile);
  //  const url = `${environment.apiUrl}/upload`;
  //  const request = new HttpRequest('POST', url, formData, {
  //    reportProgress: true
  //  });

  //  this.http.request(request).subscribe(
  //    { 
  //      next: (event: any) => {
  //        if (event.type === HttpEventType.UploadProgress) {
  //          this.uploadProgress = Math.round((100 * event.loaded) / event.total);
  //        } else if (event.type === HttpEventType.Response) {
  //          this.uploadUrl = event.body.url;
  //        }
  //      }, 
  //      error: (error: any) => {
  //        console.error(error);
  //      },
  //      complete: () => {
  //        this.working = false;
  //      }
  //    }
  //  );
  //}

  goToTermsOfUse(){
    console.log('p');
  }

  onSubmit() {
    console.log(this.signupForm);    
    if(this.signupForm.valid){
      const signUpData = new SignupData(
        this.signupForm.value.nickname,
        this.signupForm.value.surname,
        this.signupForm.value.name,
        this.signupForm.value.fathername,
        this.signupForm.value.phone,
        this.signupForm.value.email,
        this.signupForm.value.password,
        this.signupForm.value.role,
        //this.signupForm.value.confirmData
      );
      console.log(signUpData);
      this.isLoading = true;      
      this.authService.signUp(signUpData).subscribe(
        {
          next: (result) => {
            console.log(result);
            this.isLoading = false;
            this.authService.user.next(signUpData);
            this.router.navigate(['/account-page']);
          },
          error: (error) => {
            this.isLoading = false;
            console.log(error);
          },
        }
      );
      this.signupForm.reset();
    }
  }
}
