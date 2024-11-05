import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { ComponentType } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  openDialog(
    dialog: MatDialog,
    component: ComponentType<any>,
    config: MatDialogConfig | null
  ) {
   
    if (config == null) {
      config = new MatDialogConfig();
      // config.disableClose = true;
      config.autoFocus = true;
      config.panelClass = 'custom-modal';
    }
    const dialogRef = dialog.open(component, config);
 
    return dialogRef.afterClosed();
  }
}
