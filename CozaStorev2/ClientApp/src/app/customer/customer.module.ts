import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DxDataGridModule, DxSelectBoxModule, DxButtonModule } from 'devextreme-angular';

import { CustomerListComponent } from './customer-list/customer-list.component';
import {CustomerDetailsComponent} from './customer-details/customer-details.component';
  import { formArrayNameProvider } from '@angular/forms/src/directives/reactive_directives/form_group_name';
@NgModule({
  imports: [
    CommonModule,DxDataGridModule, DxSelectBoxModule, DxButtonModule,
    RouterModule.forChild([
      { path: 'list', component: CustomerListComponent },
      {path: 'details/:id', component: CustomerDetailsComponent}
    ])
  ],
  declarations: [
    CustomerListComponent,
    CustomerDetailsComponent
  ]
  
})
export class CustomerModule { }