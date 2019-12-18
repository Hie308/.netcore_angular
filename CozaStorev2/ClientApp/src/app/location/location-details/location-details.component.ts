import { Component, OnInit } from '@angular/core';
import { Location } from '../../_interfaces/location.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandService } from './../../shared/services/error-handler.service';
@Component({
  selector: 'app-location-details',
  templateUrl: './location-details.component.html',
  styleUrls: ['./location-details.component.css']
})
export class LocationDetailsComponent implements OnInit {
  public location: Location;
  public errorMessage: string = '';
  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandService) { }

  ngOnInit() {
  }

  getLocationDetails(){
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string =``
  }

}
