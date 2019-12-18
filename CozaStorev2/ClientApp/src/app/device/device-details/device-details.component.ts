import  { Component, OnInit } from '@angular/core';
import  {Device} from './../../_interfaces/device.model';
import  {User} from './../../_interfaces/user.model';
import  {Router, ActivatedRoute} from '@angular/router';
import  {RepositoryService} from './../../shared/services/repository.service';
import  {ErrorHandService} from './../../shared/services/error-handler.service';
import {environment} from './../../../environments/environment'
import {Device_Location_History} from './../../_interfaces/device_location_audit'
@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {
  public device: Device;
  public user: User;
  public device_location_histories:Device_Location_History[]; 
  public errorMessage: string='';

  constructor(private repository: RepositoryService, private router:Router,
     private activeRoute: ActivatedRoute, private errorHandler: ErrorHandService) { }
    
  ngOnInit() {
    this.getFurtherDetails();
  }
  getFurtherDetails(){
    
    let apiUrl: string =`/api/DeviceLocationHistoryAuditsController/`;
    
    this.repository.getData(apiUrl)
    .subscribe(res =>{
      this.device_location_histories= res as Device_Location_History[];
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  

}
