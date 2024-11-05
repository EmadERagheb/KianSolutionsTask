import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { EmployeeQueryParams } from '../_models/employee-query-params';
import { Paging } from '../_models/paging';
import { CreateEmployee, Employee } from '../_models/employee';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private employeesEndpoint = environment.apiUrl + '/employees';
  private http = inject(HttpClient);
  employeeParams = signal<EmployeeQueryParams>(new EmployeeQueryParams());

  getEmployees() {
    const params = this.getEmployeeParams();
    console.log(params);
    return this.http.get<Paging<Employee[]>>(this.employeesEndpoint, {
      params,
    });
  }
  getEmployee(id: number) {
    return this.http.get<Employee>(`${this.employeesEndpoint}/${id}`);
  }
  createEmployee(employee: CreateEmployee) {
    return this.http.post(this.employeesEndpoint, employee);
  }
  updateEmployee(employee: Employee) {
    return this.http.put(`${this.employeesEndpoint}/${employee.id}`, employee);
  }
  deleteEmployee(id: number) {
    return this.http.delete(`${this.employeesEndpoint}/${id}`);
  }
  private getEmployeeParams() {
    let params = new HttpParams();
    params = params.append('PageNumber', this.employeeParams().pageIndex);
    params = params.append('PageSize', this.employeeParams().pageSize);
    return params;
  }
}
