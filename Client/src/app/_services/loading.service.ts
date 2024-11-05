import { inject, Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  busyRequestCount = 0;
  excludeUrls:string[] = [];
  spinnerService = inject(NgxSpinnerService);
  busy() {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {
      type: 'ball-spin',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#333333',
      size: 'medium',
    });
  }
  idle() {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide();
    }
  }
}
