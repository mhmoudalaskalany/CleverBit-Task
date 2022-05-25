import { Directive } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';
import { CustomValidationService } from '../validators/custom-validation.service';

@Directive({
  selector: '[appDeviceArabicNamePattern]',
  providers: [{ provide: NG_VALIDATORS, useExisting: DeviceArabicNamePatternDirective, multi: true }]
})
export class DeviceArabicNamePatternDirective implements Validator {

  constructor(private customValidator: CustomValidationService) {
  }

  validate(control: AbstractControl): { [key: string]: any } | null {
    return this.customValidator.deviceArabicNamePatternValidator()(control);
  }
}
