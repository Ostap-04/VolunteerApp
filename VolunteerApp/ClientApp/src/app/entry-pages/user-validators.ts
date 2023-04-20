import { ValidationErrors, ValidatorFn, AbstractControl, AsyncValidatorFn } from "@angular/forms";
import { Observable } from "rxjs";
import { map, debounceTime, distinctUntilChanged, switchMap } from "rxjs/operators";

import { AuthorizationService } from "../shared/services/authorization.service";

export class UserValidators {
  constructor() {}
  
  static patternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      if(!control.value) {
        return null;
      }

      const valid = regex.test(control.value);

      return valid ? null : error;
    };
  }

  static matchValidator(control: AbstractControl) {
    const password: string = control.get('password')?.value;
    const confirmPassword: string = control.get('confirmPassword')?.value;
    
    if(!confirmPassword?.length) {
      return null;
    }

    if(confirmPassword !== password) {
      control.get('confirmPassword')?.setErrors({mismatch: true});
    } else {
      return null;
    }
  }
  
  
  static isUniqueNickName(authService: AuthorizationService): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return control.valueChanges.pipe(
        debounceTime(2000),
        distinctUntilChanged(),
        switchMap((lastValue) => authService.checkNickname(lastValue)),
        map((result: boolean) => result ? {notUniqueNickName: true} : null)
      );    
    };
  }

  static isUniquePhone(authService: AuthorizationService): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if(control.hasError('invalidPhone')){
        return null;
      } 
      return authService.checkPhoneNumber(control.value)
      .pipe(
        debounceTime(2000),
        distinctUntilChanged(),
        map((result: boolean) => result ? {notUniquePhone: true} : null)
      );
    };
  }
}
