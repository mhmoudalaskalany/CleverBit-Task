import { TranslationService } from './../../../../core/services/localization/translation.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'core/services/auth/auth.service';
import { Router } from '@angular/router';
import { StorageService } from 'core/services/storage/storage.service';
import { Shell } from 'base/components/shell';
import { AlertService } from 'core/services/alert/alert.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginModel: any = {};
  loginForm!: FormGroup;
  get Storage(): StorageService { return Shell.Injector.get(StorageService); }
  get Auth(): AuthService { return Shell.Injector.get(AuthService); }
  get Alert(): AlertService { return Shell.Injector.get(AlertService); }
  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }
  get Fb(): FormBuilder { return Shell.Injector.get(FormBuilder); }
  constructor(
    private router: Router
  ) { }

  ngOnInit() {
    if (this.Storage.getToken()) {
      this.router.navigate(['/main/home']);
    }
    this.initLoginForm();
  }

  initLoginForm() {
    this.loginForm = this.Fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    debugger;
    this.Auth.login(this.loginForm.value).subscribe((res: any) => {
      console.log(res.status);
      if (res.status === 200) {
        this.Storage.setItem('token', res.data.token);
        this.router.navigate(['/main/home']);
      } else {
        this.Alert.showError(this.Localize.translate.instant('Data.' + res.message));
      }
    });
  }
}
