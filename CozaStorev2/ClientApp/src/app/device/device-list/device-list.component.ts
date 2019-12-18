import { Component, OnInit, Inject } from '@angular/core';
import {RepositoryService} from './../../shared/services/repository.service';
import {Device} from './../../_interfaces/device.model';
import { Router} from '@angular/router';
import { ErrorHandService } from '../../shared/services/error-handler.service';
import {environment} from './../../../environments/environment';
declare var $: any; 
import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
var URL = "http://localhost:57890/api/";
import {Device_Location_History} from './../../_interfaces/device_location_audit'


@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  public devices: Device[];
  dataSource: any;
  deviceData: any;
  locationsData: any;
  usersData: any;
  public device_location_histories: any;
  public apiAddress: string = "api/DevicesController";
  popupVisible = false;
  public errorMessage: string= '';
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private router: Router, private http: HttpClient) {
    this.okClicked=this.okClicked.bind(this);
    this.dataSource = new CustomStore({
      key: "id",
      load: () => this.repository.getData(this.apiAddress).toPromise(),

      insert: (values) => this.repository.create(this.apiAddress,
        JSON.stringify(values)).toPromise(),

      update: (key, values) => this.repository.update(this.apiAddress + '/' + key,
        JSON.stringify(values)
        ).toPromise().then((data: any) => {
          return data;
        }),

      remove: (key) => this.repository.delete(this.apiAddress + '/' + key).toPromise()
        .then((data: any) => {
          return data;
        })
    });

    //this.repository.getData("api/owner")
    //  .subscribe(res => {
    //    this.owners = res as Owner[]);
    this.deviceData = {
      paginate: true,
      store: new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.repository.getData("api/DevicesController").toPromise(),
      })
    };

    this.locationsData  = {
      paginate: true,
      store: new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.repository.getData("api/LocationsController").toPromise(),
      })
    };

    this.usersData  = {
      paginate: true,
      store: new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.repository.getData("api/UsersController").toPromise(),
      })
    };
    
    this.device_location_histories  = {
      paginate: true,
      store: new CustomStore({
        key: "dlhistoryId",
        loadMode: "raw",
        load: () => this.repository.getData("api/DeviceLocationHistoryAuditsController").toPromise(),
      })
    };
   }

  ngOnInit() {
    this.getAllDevices();
    
  }
  public getAllDevices(){
    let apiAddress: string ="api/DevicesController";
    this.repository.getData(apiAddress).subscribe(
      res=> {
        this.devices = res as Device[];
      },
      (error)=>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    )

  }
  public getFurtherDetails(id){
    let detailsUrl: string =`/device/details/${id}`;
    this.router.navigate([detailsUrl]);
  }
  
  public redirectToUpdatePage(id){
    let updateUrl: string = `/device/update/${id}`;
    this.router.navigate([updateUrl]);
}
public redirectToDeletePage(id){
  let deleteUrl: string = `/device/delete/${id}`;
  this.router.navigate([deleteUrl]);
}
public deleteDevice(id) {
  let deleteUrl: string = `api/DevicesController/${id}`;
  this.repository.delete(deleteUrl)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })

}
public redirectToDeviceList(){
  
  //this.router.navigate(['/device/list']);
  //window.location.reload()
}

public okClicked(event : Event) {
  //alert("succesful");
  if(this.popupVisible == false)
    this.popupVisible = true;
  else
  this.popupVisible = false
  //window.location.reload()
  //this.router.navigate(['/device/list']);
  
}
}
