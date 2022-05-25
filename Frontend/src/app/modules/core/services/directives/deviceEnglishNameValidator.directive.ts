import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';
import { CustomValidationService } from '../validators/custom-validation.service';

@Directive({
  selector: '[appDeviceEnglishNamePattern]',
  providers: [{ provide: NG_VALIDATORS, useExisting: DeviceEnglishNamePatternDirective, multi: true }]
})
export class DeviceEnglishNamePatternDirective implements Validator {

  constructor(private customValidator: CustomValidationService) {
  }

  validate(control: AbstractControl): { [key: string]: any } | null {
    return this.customValidator.deviceEnglishNamePatternValidator()(control);
  }
}
