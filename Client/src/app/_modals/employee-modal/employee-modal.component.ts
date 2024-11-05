import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeService } from '../../_services/employee.service';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { Employee } from '../../_models/employee';
import { TextInputComponent } from '../../_forms/text-input/text-input.component';
import { MatButtonModule } from '@angular/material/button';
import { NgFor } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-employee-modal',
  standalone: true,
  imports: [
    MatDialogModule,
    ReactiveFormsModule,
    TextInputComponent,
    MatButtonModule,
    NgFor,
    MatIconModule,
  ],
  templateUrl: './employee-modal.component.html',
  styleUrl: './employee-modal.component.scss',
})
export class EmployeeModalComponent {
  private fb = inject(FormBuilder);


  private dialogRef = inject(MatDialogRef);

  data: {
    title: string;
    employee?: Employee;
  } = inject(MAT_DIALOG_DATA);
  disableBTN = signal<boolean>(true);

  employeeForm = this.fb.group({
    firstName: [this.data.employee?.firstName, Validators.required],
    lastName: [this.data.employee?.lastName, Validators.required],
    userName: [this.data.employee?.userName, Validators.required],
    active: [this.data.employee?.active ?? false],
  });

  get firstName() {
    return this.employeeForm.controls['firstName'];
  }
  get lastName() {
    return this.employeeForm.controls['lastName'];
  }
  get userName() {
    return this.employeeForm.controls['userName'];
  }
  get active() {
    return this.employeeForm.controls['active'];
  }

  save() {
    this.dialogRef.close(this.employeeForm.value);
  }
  close() {
    this.dialogRef.close();
  }
  ngOnInit(): void {}

}
