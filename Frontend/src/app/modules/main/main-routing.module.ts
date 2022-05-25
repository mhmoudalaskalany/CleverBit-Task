import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'core/services/guards/authguard.guard';
import { LayoutComponent } from './components/layout/layout.component';


const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                redirectTo: 'home',
                pathMatch: 'full'
            },
            {
                path: 'home',
                canActivate: [AuthGuard],
                loadChildren: () => import('../features/home/home.module').then((m) => m.HomeModule),
            },
            {
                path: 'employee',
                canActivate: [AuthGuard],
                loadChildren: () => import('../features/employee/employee.module').then((m) => m.EmployeeModule),
            },
        ]
    }


];

@NgModule({
    imports: [RouterModule.forChild(routes)],


    exports: [RouterModule]
})
export class MainRoutingModule { }
