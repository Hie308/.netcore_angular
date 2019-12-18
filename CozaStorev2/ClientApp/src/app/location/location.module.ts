import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {LocationListComponent } from './location-list/location-list.component';
import { LocationDetailsComponent } from './location-details/location-details.component';
import { SharedModule } from './../shared/shared.module';
import { DevExtremeModule, DxDataGridModule, DxButtonModule, DxListModule, DxSelectBoxModule  } from 'devextreme-angular';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ReactiveFormsModule} from '@angular/forms';

@NgModule({
    imports: [
      CommonModule, SharedModule,
      ReactiveFormsModule,
      DevExtremeModule,
      DxDataGridModule,
      DxButtonModule,
      DxListModule,
      DxSelectBoxModule,
      RouterModule.forChild([
        { path: 'list', component: LocationListComponent },
        { path: 'details/:id', component: LocationDetailsComponent}
      ])
    ],
    declarations: [
        LocationListComponent,
        LocationDetailsComponent
    ]
  })

export class LocationModule { }
