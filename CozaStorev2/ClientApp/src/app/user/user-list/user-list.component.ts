import { Component, OnInit } from '@angular/core';
import{RepositoryService} from './../../shared/services/repository.service';
import{User} from './../../_interfaces/user.model';
import{ErrorHandService} from './../../shared/services/error-handler.service'
import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import CustomStore from "devextreme/data/custom_store";

var URL = "http://localhost:57890/api/";

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public apiAddress: string = "api/UsersController";
  public users: User[];
  userData: any;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandService, private http: HttpClient) {
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
    this.userData = {
      paginate: true,
      store: new CustomStore({
        key: "Value",
        loadMode: "raw",
        load: () => this.repository.getData("api/UsersController").toPromise(),
      })
    };

   }
  public errorMessage: string= '';
  dataSource: any;


  ngOnInit() {
    this.getAllUser();
  }
  public getAllUser(){
    let apiAddress: string ="api/UsersController";
    this.repository.getData(apiAddress).subscribe(
      res=> {
        this.users = res as User[];
      },
      (error)=>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    )

  }

}
