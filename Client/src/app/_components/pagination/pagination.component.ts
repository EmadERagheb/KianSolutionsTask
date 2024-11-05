import { NgIf } from '@angular/common';
import { Component, input, output } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { PageChangedEvent, PaginationModule } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [PaginationModule, FormsModule,NgIf],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.scss',
})
export class PaginationComponent {
  totalItems = input.required<number>();
  pageSize = input.required<number>();
  pageNumber = input.required<number>();
  pageChanges = output<number>();

  onPageChange(event: PageChangedEvent) {
    if (this.pageNumber() != event.page) this.pageChanges.emit(event.page);
  }
}
