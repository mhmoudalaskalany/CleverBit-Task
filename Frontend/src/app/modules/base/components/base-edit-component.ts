import { OnInit, Directive } from '@angular/core';
import { HttpService } from 'core/services/http/http.service';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'core/services/alert/alert.service';
import { Shell } from './shell';
import { TranslationService } from 'core/services/localization/translation.service';
import { FormGroup } from '@angular/forms';

@Directive()
export abstract class BaseEditComponent implements OnInit {
  constructor(protected route: ActivatedRoute) { }
  model: any = {};
  form: FormGroup;
  isNew = true;
  id: string;
  abstract get Service(): HttpService;
  get Alert(): AlertService { return Shell.Injector.get(AlertService); }
  get Localize(): TranslationService { return Shell.Injector.get(TranslationService); }
  get Route(): Router { return Shell.Injector.get(Router); }

  protected submitReactiveNew(endpoint?: string): Observable<any> {
    return this.Service.postReq(endpoint != null ? endpoint : 'Add', this.form.value);
  }
  protected submitReactiveUpdate(endpoint?: string): Observable<any> {
    return this.Service.putReq(endpoint != null ? endpoint : 'Update', this.form.value);
  }
  protected GetModelFromServer(id: any, endpoint?: string): Observable<any> {
    return this.Service.getHeaderReq(endpoint != null ? endpoint : 'Get', id);
  }




  submitReactive(endpoint?: string): void {
    if (this.isNew) {
      this.submitReactiveNew(endpoint).subscribe(
        (data: any) => {
          if (data.status !== 201) {
            this.Alert.showError(data.message);
            return false;
          }
          this.Alert.showSuccess(
            this.Localize.translate.instant('Data.AddSuccess')
          );
          this.Redirect();
        },
        (error) => {
          this.Alert.showError(
            this.Localize.translate.instant('Data.AddError')
          );
        }
      );
    } else {
      this.submitReactiveUpdate(endpoint).subscribe(
        (data: any) => {
          if (data.status !== 202) {
            this.Alert.showError(data.message);
            return false;
          }
          this.Alert.showSuccess(
            this.Localize.translate.instant('Data.UpdateSuccess')
          );
          this.Redirect();
        },
        (error) => {
          this.Alert.showError(
            this.Localize.translate.instant('Data.UpdateError')
          );
          console.log('error at submitting', error);
        }
      );
    }

  }

  getRouteParams() {
    this.route.params.subscribe((p: any) => {
      if (p.id != null && p.id !== undefined) {
        this.isNew = false;
        this.id = p.id;
        this.Get(this.id);
      }
    });
  }

  Redirect(url?: string) {
    const currentRoute = this.Route.url;
    const index = currentRoute.lastIndexOf(url ? url : '/');
    const str = currentRoute.substring(0, index);
    this.Route.navigate([str]);
  }
  Get(id: any): void {
    this.GetModelFromServer(id).subscribe(
      (data: any) => {
        this.model = data.data;
        console.log(this.model);
      },
      (error) => {
        this.Alert.showError(this.Localize.translate.instant('Data.GetError'));
        console.log(error);

      }
    );
  }

  ngOnInit(): void {
    this.getRouteParams();
  }

  preventDefault(event) {
    event.preventDefault();
  }


}
