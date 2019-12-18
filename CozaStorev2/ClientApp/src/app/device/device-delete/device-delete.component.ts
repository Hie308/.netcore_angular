import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ErrorHandService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Device } from './../../_interfaces/device.model';
declare var $: any 
@Component({
  selector: 'app-device-delete',
  templateUrl: './device-delete.component.html',
  styleUrls: ['./device-delete.component.css']
})
export class DeviceDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public device: Device;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getDeviceById();
  }
  private getDeviceById() {
    let deviceId: string = this.activeRoute.snapshot.params['id'];
    let deviceByIdUrl: string = `api/DevicesController/${deviceId}`;
   
    this.repository.getData(deviceByIdUrl)
      .subscribe(res => {
        this.device = res as Device;
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }
   
  public redirectToDeviceList() {
    this.router.navigate(['/device/list']);
  }
  public deleteDevice() {
    let deleteUrl: string = `api/DevicesController/${this.device.Id}`;
    this.repository.delete(deleteUrl)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }
}
