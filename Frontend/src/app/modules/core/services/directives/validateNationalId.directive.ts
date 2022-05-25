import { Shell } from 'base/components/shell';
import { Directive, forwardRef, Input } from '@angular/core';
import {
  AbstractControl,
  NG_ASYNC_VALIDATORS,
  AsyncValidator,
  ValidationErrors,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { CustomValidationService } from '../validators/custom-validation.service';
import { ConfigService } from '../config/config.service';
import { HttpClient } from '@angular/common/http';

@Directive({
  selector: '[appValidateNationalId]',
  providers: [
    {
      provide: NG_ASYNC_VALIDATORS,
      useExisting: forwardRef(() => ValidateNationalIdDirective),
      multi: true,
    },
  ],
})
export class ValidateNationalIdDirective implements AsyncValidator {
  get config(): ConfigService {
    return Shell.Injector.get(ConfigService);
  }
  get http(): HttpClient {
    return Shell.Injector.get(HttpClient);
  }
  @Input('appValidateNationalId') userId: string;
  constructor(private customValidator: CustomValidationService) {}

  validate(control: AbstractControl): Observable<ValidationErrors | null> {
    const obs = this.customValidator.nationalIdValidator(control, this.userId);
    return obs;
  }
}
