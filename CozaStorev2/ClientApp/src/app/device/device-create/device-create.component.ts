import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import {DeviceForCreation} from './../../_interfaces/DeviceForCreation';
import {ErrorHandService} from './../../shared/services/error-handler.service';
import {RepositoryService} from './../../shared/services/repository.service';
declare var $: any 

@Component({
  selector: 'app-device-create',
  templateUrl: './device-create.component.html',
  styleUrls: ['./device-create.component.css']
})
export class DeviceCreateComponent implements OnInit {
  public errorMessage: string ='';
  public deviceForm :FormGroup;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private router: Router, private datePipe: DatePipe) { }
  

  ngOnInit() {
    this.deviceForm = new FormGroup({
      name: new FormControl ('',[Validators.required, Validators.maxLength(50)]),
      recievedDate: new FormControl('',[Validators.required]),
      serialNumber: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      ownerId: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      currentLoca: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      ProductType: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      BranchName: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      Origin: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      QualityStatus: new FormControl('',[Validators.required, Validators.maxLength(100)] ),
      Quantity: new FormControl('',[Validators.required, Validators.maxLength(100)] ),

    });
  }
  public validateControl(controlName: string){
    if( this.deviceForm.controls[controlName].invalid && this.deviceForm.controls[controlName].touched)
      return true;
    return false;
  }

  public hasError(controlName: string, errorName: string){
    if( this.deviceForm.controls[controlName].invalid && this.deviceForm.controls[controlName].touched)
      return true;
    return false;
  }

  public executeDatePicker(event){
    this.deviceForm.patchValue({'dateOfBirth': event});
  }

  public createDevice(deviceFormValue){
    if(this.deviceForm.valid){
      this.executeDeviceCreation(deviceFormValue);
    }
  }

  private executeDeviceCreation(deviceFormValue){
    let device: DeviceForCreation ={
      FullName: deviceFormValue.name,
      ProductType: deviceFormValue.ProductType ,
      BranchName: deviceFormValue.BranchName,
      Origin: deviceFormValue.Origin,
      SerialNumber: deviceFormValue.serialNumber,
      QualityStatus:  deviceFormValue.QualityStatus,
      OwnerId: deviceFormValue.ownerId,
      CurrentLocationId: deviceFormValue.currentLoca,
      Quantity: deviceFormValue.Quantity,

      //recievedDate: this.datePipe.transform(deviceFormValue.recievedDate, 'dd-MM-yyyy'),
      ReceivedDate: deviceFormValue.recievedDate,
     
      
    }
    let apiUrl = 'api/DevicesController';
    this.repository.create(apiUrl, device).subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }
  public redirectToDeviceList(){
    this.router.navigate(['/device/list']);
  }

  
}
