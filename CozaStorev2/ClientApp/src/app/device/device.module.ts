import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import {DeviceListComponent} from './device-list/device-list.component';
import {DeviceDetailsComponent} from './device-details/device-details.component';
import { DeviceCreateComponent } from './device-create/device-create.component';
import { ReactiveFormsModule} from '@angular/forms';
import { SharedModule } from './../shared/shared.module';
import { DeviceUpdateComponent } from './device-update/device-update.component';
import { DeviceDeleteComponent } from './device-delete/device-delete.component';
import { DevExtremeModule, DxDataGridModule,DxButtonModule,DxListModule,DxSelectBoxModule  } from 'devextreme-angular'; 
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    DevExtremeModule,
    DxDataGridModule,
    DxButtonModule,
    DxListModule,
    DxSelectBoxModule,
    
    RouterModule.forChild([
        { path:'list', component: DeviceListComponent },
        { path:'details/:id', component: DeviceDetailsComponent},
        { path:'create', component: DeviceCreateComponent},
        { path: 'update/:id', component: DeviceUpdateComponent},
        { path: 'delete/:id', component: DeviceUpdateComponent},
    ])
    
  ],
  declarations: [
      DeviceListComponent,
      DeviceDetailsComponent,
      DeviceCreateComponent,
      DeviceUpdateComponent,
      DeviceDeleteComponent    
  ]
})
export class DeviceModule { }
platformBrowserDynamic().bootstrapModule(DeviceModule);
