import { Component, OnInit } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service'
import { Customer } from './../../_interfaces/customer.model';
import { ErrorHandService } from './../../shared/services/error-handler.service';
import { error } from 'util';
import { DxDataGridModule, DxSelectBoxModule, DxButtonModule } from 'devextreme-angular';

import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
var URL = "https://localhost:44386/api";
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  public errorMessage: string ='';
  public custs: Customer[];

  dataSource: any;
  customersData: any;
  shippersData: any;
  refreshModes: string[];
  refreshMode: string;
  requests: string[] = [];

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private http: HttpClient) { 
    this.refreshMode = "reshape";
    this.refreshModes = ["full", "reshape", "repaint"];

    this.dataSource = new CustomStore({
        key: "Id",
        load: () => this.sendRequest(URL + "/DevicesController"),
        insert: (values) => this.sendRequest(URL + "/DevicesController", "POST", {
            values: JSON.stringify(values)
        }),
        update: (key, values) => this.sendRequest(URL + "/DevicesController", "PUT", {
            key: key,
            values: JSON.stringify(values)
        }),
        remove: (key) => this.sendRequest(URL + "/DevicesController", "DELETE", {
            key: key
        })
      });
      this.customersData = {
        paginate: true,
        store: new CustomStore({
            key: "Value",
            loadMode: "raw",
            load: () => this.sendRequest(URL + "/CustomersLookup")
        })
    };

    this.shippersData = new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.sendRequest(URL + "/ShippersLookup")
    });
    

  }
  sendRequest(url: string, method: string = "GET", data: any = {}): any {
    this.logRequest(method, url, data);

    let httpParams = new HttpParams({ fromObject: data });
    let httpOptions = { withCredentials: true, body: httpParams };
    let result;

    switch(method) {
        case "GET":
            result = this.http.get(url, httpOptions);
            break;
        case "PUT":
            result = this.http.put(url, httpParams, httpOptions);
            break;
        case "POST":
            result = this.http.post(url, httpParams, httpOptions);
            break;
        case "DELETE":
            result = this.http.delete(url, httpOptions);
            break;
    }

    return result
        .toPromise()
        .then((data: any) => {
            return method === "GET" ? data.data : data;
        })
        .catch(e => {
            throw e && e.error && e.error.Message;
        });
}

logRequest(method: string, url: string, data: object): void {
  var args = Object.keys(data || {}).map(function(key) {
      return key + "=" + data[key];
  }).join(" ");

  var time = formatDate(new Date(), "HH:mm:ss");

  this.requests.unshift([time, method, url.slice(URL.length), args].join(" "))
}

clearRequests() {
  this.requests = [];
}

ngOnInit() {
  this.getAllCusts();
}
public getAllCusts(){
  let apiAddress: string ="/api/CustomersController/Customer"
  this.repository.getData(apiAddress)
  .subscribe(res=>{
    this.custs = res as Customer[];},
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage=this.errorHandler.errorMessage;
    }
    )
}

}
