import { Component, inject, OnInit, signal } from '@angular/core';
import { EmployeeService } from '../../_services/employee.service';
import { Paging } from '../../_models/paging';
import { Employee } from '../../_models/employee';
import { PagingHeaderComponent } from '../../_components/paging-header/paging-header.component';

import { DialogService } from '../../_modals/dialog.service';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeModalComponent } from '../../_modals/employee-modal/employee-modal.component';
import { filter } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { PaginationComponent } from '../../_components/pagination/pagination.component';
import { PageChangedEvent, PaginationModule } from 'ngx-bootstrap/pagination';
import { ToastrService } from 'ngx-toastr';
import { MatConfirmationDialogComponent } from '../../_modals/mat-confirmation-dialog/mat-confirmation-dialog.component';

@Component({
  selector: 'app-employees-list',
  standalone: true,
  imports: [
    PagingHeaderComponent,
    PaginationComponent,
    MatIconModule,
    MatButtonModule,

    PaginationModule,
    MatTooltipModule,
  ],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.scss',
})
export class EmployeesListComponent implements OnInit {

  private employeeService = inject(EmployeeService);
  private dialogService = inject(DialogService);
  private toastrService = inject(ToastrService);
  private dialog = inject(MatDialog);
  employees = signal<Paging<Employee[]> | null>(null);
  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getEmployees().subscribe({
      next: (employees) => {
        this.employees.set(employees);
        console.log(this.employees());
      },
    });
  }
  openDialog(id: number = 0) {
    if (id === 0) {
      this.dialogService
        .openDialog(this.dialog, EmployeeModalComponent, {
          panelClass: 'custom-modal',
          autoFocus: true,
          disableClose: true,
          data: { title: 'Add Employee' },
        })
        .pipe(filter((value) => !!value))
        .subscribe({
          next: (result) => {
            this.employeeService.createEmployee(result).subscribe({
              next: () => {
                this.loadEmployees();
                this.toastrService.success(
                  'Employee added successfully',
                  'Success'
                );
              },
              error: (error) => {
                this.toastrService.error('Error adding employee', 'Error');
              },
            });
          },
        });
    } else {
      this.employeeService.getEmployee(id).subscribe({
        next: (employee) => {
          this.dialogService
            .openDialog(this.dialog, EmployeeModalComponent, {
              panelClass: 'custom-modal',
              autoFocus: true,
              disableClose: true,
              data: { title: 'Edit Employee', employee: employee },
            })
            .pipe(filter((value) => !!value))
            .subscribe({
              next: (result) => {
                this.employeeService
                  .updateEmployee({ id, ...result })
                  .subscribe({
                    next: () => {
                      this.loadEmployees();
                      this.toastrService.success(
                        'Employee updated successfully',
                        'Success'
                      );
                    },
                    error: (error) => {
                      this.toastrService.error(
                        'Error updating employee',
                        'Error'
                      );
                    },
                  });
              },
            });
        },
      });
    }
  }
  deleteEmployee(id: number) {
    this.dialogService
      .openDialog(this.dialog,MatConfirmationDialogComponent,{
        // panelClass: 'custom-modal',
        autoFocus: true,
        disableClose: true,
        data: { title: 'Delete Employee', content: 'Are you sure you want to delete this employee?' },
      })
      .pipe(filter((value) => !!value))
      .subscribe({
        next: () => {
          this.employeeService.deleteEmployee(id).subscribe({
            next: () => {
              this.loadEmployees();
              this.toastrService.success('Employee deleted successfully', 'Success');
            },
            error: (error) => {
              this.toastrService.error('Error deleting employee', 'Error');
            },
          });
        },
      });
    }
  onPageChanges(event: number) {
    if (this.employeeService.employeeParams().pageIndex !== event) {
      this.employeeService.employeeParams().pageIndex = event;
      this.loadEmployees();
    }
  }
}
