import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { DevExtremeModule, DxDataGridModule,DxButtonModule,DxListModule,DxSelectBoxModule  } from 'devextreme-angular'; 
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

@NgModule({
    imports:[
        CommonModule,
        DevExtremeModule,
        DxDataGridModule,
        DxButtonModule,
        DxListModule,
        DxSelectBoxModule,
        RouterModule.forChild([
            { path: 'list', component: UserListComponent}
        ])
    ],
    declarations: [
        UserListComponent
    ]
})
export class UserModule{}
platformBrowserDynamic().bootstrapModule(UserModule);