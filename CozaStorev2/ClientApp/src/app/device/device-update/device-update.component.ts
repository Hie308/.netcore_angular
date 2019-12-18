import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {ErrorHandService} from './../../shared/services/error-handler.service';
import {RepositoryService} from './../../shared/services/repository.service';
import {Device} from './../../_interfaces/device.model';
import { stringify } from 'querystring';
declare var $: any 
@Component({
  selector: 'app-device-update',
  templateUrl: './device-update.component.html',
  styleUrls: ['./device-update.component.css']
})
export class DeviceUpdateComponent implements OnInit {
  public errorMessage: string = '';
  public device: Device={
      Id: undefined,
      FullName : undefined,
      ProductType:  undefined,
      BranchName: undefined,
      Origin :  undefined,
      SerialNumber:undefined,
      QualityStatus : undefined,
      OwnerId  :undefined,
      CurrentLocationId : undefined,
      Quantity: undefined,
      ReceivedDate: undefined,
      LocationHistory: undefined

  };
  public deviceForm: FormGroup;
  public deviceId: String;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.deviceForm = new FormGroup({
      name:new FormControl('', [Validators.required, Validators.maxLength(30)]),
      ReceivedDate: new FormControl('',[Validators.required]),
      SerialNumber: new FormControl ('', [Validators.required, Validators.maxLength(30)]),
      OwnerId: new FormControl ('', [Validators.required, Validators.maxLength(30)]),
      CurrentLocationId: new FormControl ('', [Validators.required, Validators.maxLength(30)]),
      ProductType: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      BranchName: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      Origin: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      QualityStatus: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      Quantity: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
    });
    this.getDeviceById();
    
  }
  public getDeviceById() {
     this.deviceId = this.activeRoute.snapshot.params['id'];
    
    let deviceByIdUrl: string = `api/DevicesController/${this.deviceId}`;
    
    // this.repository.getData(deviceByIdUrl)
    //   .subscribe(res => {
    //     this.device = res as Device;
    //     this.deviceForm.patchValue(this.device);
    //   },
    //   (error) => {
    //     this.errorHandler.handleError(error);
    //     this.errorMessage = this.errorHandler.errorMessage;
    //   })
  }
  public validateControl(controlName: string) {
    if (this.deviceForm.controls[controlName].invalid && this.deviceForm.controls[controlName].touched)
      return true;
   
    return false;
  }
   
  public hasError(controlName: string, errorName: string) {
    if (this.deviceForm.controls[controlName].hasError(errorName))
      return true;
   
    return false;
  }
   
  // public executeDatePicker(event) {
  //   this.deviceForm.patchValue({ 'dateOfBirth': event });
  // }
   
  public redirectToDeviceList(){
    this.router.navigate(['/device/list']);
  }

  public updateDevice(deviceFormValue) {
    if (this.deviceForm.valid) {
      this.executeDeviceUpdate(deviceFormValue);
    }
  }
  public executeDeviceUpdate(deviceFormValue) {
      this.device.Id = Number.parseInt(this.deviceId.toString());
      this.device.FullName = deviceFormValue.name;
      this.device.ProductType = deviceFormValue.ProductType
      this.device.BranchName = deviceFormValue.BranchName;
      this.device.Origin = deviceFormValue.Origin;
      this.device.SerialNumber= deviceFormValue.SerialNumber;
      this.device.QualityStatus = deviceFormValue.QualityStatus;
      this.device.OwnerId= deviceFormValue.OwnerId;
      this.device.CurrentLocationId = deviceFormValue.CurrentLocationId;
      this.device.Quantity= deviceFormValue.Quantity;
      this.device.ReceivedDate= deviceFormValue.ReceivedDate;

    console.log(this.device);
    console.log(this.device[1]);
    console.log(this.device[0]);
    console.log(JSON.stringify(this.device[0]));
    let apiUrl = `api/DevicesController/${this.deviceId}`;
    this.repository.update(apiUrl, JSON.stringify(this.device))
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

}
