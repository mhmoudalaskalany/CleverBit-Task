import { Component, OnInit } from '@angular/core';
import { Shell } from 'base/components/shell';
import { BaseListComponent } from 'base/components/base-list-component';
import { TableOptions } from 'shared/components/data-table/models/tableOptions';
import { EmployeeService } from 'features/employee/services/employee.service';

@Component({
  selector: 'app-all-employee',
  templateUrl: './all-employee.component.html',
  styleUrls: ['./all-employee.component.scss'],
})
export class AllEmployeeComponent extends BaseListComponent implements OnInit {
  regions: any[] = [];
  employees: any[] = [];
  regionId;
  // Services
  get Service(): EmployeeService { return Shell.Injector.get(EmployeeService); }
  constructor() {
    super();
  }

  ngOnInit(): void {
    this.getRegions();
  }

  getRegions(): void {
    this.Service.getRegions().subscribe((res: any) => {
      this.regions = res.data;
    });
  }

  getEmployeesByRegion(event): void {
    this.Service.getEmployeeByRegion(event).subscribe((res: any) => {
      this.employees = [];
      this.employees = res.data;
    })
  }


}
