import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'validationHandler'
})
export class ValidationHandlerPipe implements PipeTransform {

  transform(value: any, ...args: unknown[]): unknown {
    value = JSON.stringify(value);

    let message = '';
    let customMessage = '';
    const pattern = /"(.*?)"/;
    const matches = value.match(pattern).length === 0 ? (value.match(pattern)[0]).replace('"', '') : value.match(pattern)[1];

    if (matches === 'min') {
      customMessage = JSON.parse(value).min.requiredLength;
    }

    switch (matches) {
      case 'required':
        message = 'This field is required.';
        break;
      case 'min':
        message = `This Min Number is (${customMessage}).`;
        break;
      case 'pattern':
        message = `input not in required format: 172.163.5.4.`;
        break;
      default:
        message = "undefined error"
        break;
    }

    return message;
  }

}
