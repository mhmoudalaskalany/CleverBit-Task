import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'core/services/guards/authguard.guard';
import { LoginComponent } from 'features/account/components/login/login.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  { path: '', redirectTo: '/', pathMatch: 'full' },
  {
    path: 'error',
    loadChildren: () => import('./modules/features/error/error.module').then(m => m.ErrorModule)
  },
  {
    path: 'main',
    loadChildren: () => import('main/main.module').then((m) => m.MainModule),
    canActivate: [AuthGuard],
    data: { permission: 'allowAll' }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
