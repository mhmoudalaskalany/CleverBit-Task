
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'shared/shared.module';
import { EmployeeRoutingModule } from './employee-routing.module';
import { AllEmployeeComponent } from './components/all-employee/all-employee.component';


@NgModule({
    declarations: [
        AllEmployeeComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        EmployeeRoutingModule
    ]
})
export class EmployeeModule { }
