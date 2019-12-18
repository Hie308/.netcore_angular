import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorModalComponent } from './modals/error-modal/error-modal.component';
import { SuccessModalComponent } from './modals/success-modal/success-modal.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
 
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
  ErrorModalComponent,
  SuccessModalComponent,
  ConfirmDialogComponent
],
  exports: [
    ErrorModalComponent,
    SuccessModalComponent
  ]
})
export class SharedModule { }