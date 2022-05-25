import { Observable } from 'rxjs';
import { HttpService } from 'core/services/http/http.service';
import { Injectable } from "@angular/core";
import { Result } from 'shared/models/result';
import { Employee } from '../models/employee';

@Injectable({
    providedIn: 'root'
})

export class EmployeeService extends HttpService {
    get baseUrl(): string {
        return 'Employees/'
    }


    getAll(): Observable<Result<Employee>> {
        return this.getTypedReq<Employee>('GetAll');
    }

    getEmployeeByRegion(event): Observable<Result<Employee>> {
        return this.getTypedReq('getEmployeesByRegion/' + event.id);
    }

    getRegions(): Observable<any> {
        return this.http.get(this.serverUrl + 'Regions/GetAll');
    }
}