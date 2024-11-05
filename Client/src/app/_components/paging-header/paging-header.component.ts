import { NgIf } from '@angular/common';
import { Component, input } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  standalone: true,
  imports: [NgIf],
  templateUrl: './paging-header.component.html',
  styleUrl: './paging-header.component.scss',
})
export class PagingHeaderComponent {
  totalItems = input.required<number>();
  pageSize = input.required<number>();
  pageIndex = input.required<number>();
}
