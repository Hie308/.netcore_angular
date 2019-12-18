import { Component, OnInit } from '@angular/core';
import { RepositoryService} from './../../shared/services/repository.service';
import {Location} from './../../_interfaces/location.model';
import { ErrorHandService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

@Component({
  selector: 'app-location-list',
  templateUrl: './location-list.component.html',
  styleUrls: ['./location-list.component.css']
})
export class LocationListComponent implements OnInit {
  public locations: Location[];
  public errorMessage: string = '';
  dataSource: any;
  locationsData: any;
  public apiAddress: string = "api/LocationsController";


  constructor(private repository:RepositoryService,  private errorHandler: ErrorHandService,  private router: Router,  private http: HttpClient) { 
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


    this.locationsData  = {
      paginate: true,
      store: new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.repository.getData("api/LocationsController").toPromise(),
      })
    };

  }
  
  ngOnInit() {
    this.getAllLocations();
  }
  public getAllLocations(){
    let apiAddress: string ="api/LocationsController";
    this.repository.getData(apiAddress)
    .subscribe(res =>{
      this.locations = res as Location[];
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }
  public getLocationDetails(id){
    let detailsUrl: string =`/location/details/${id}`
    this.router.navigate([detailsUrl]);
  }

}
