
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MenuComponent } from './menu/menu.component';
//import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import {EnvironmentUrlService} from './shared/services/environment-url.service'
import {RepositoryService} from './shared/services/repository.service';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import {ErrorHandService} from './shared/services/error-handler.service';

import {DatePipe} from '@angular/common';
import { DxCircularGaugeModule, DxLinearGaugeModule, DxSliderModule } from 'devextreme-angular'
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ErrorStateMatcher } from '@angular/material/core';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MenuComponent,
    InternalServerComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
    //UserListComponent,
    
    //CustomerListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    DxCircularGaugeModule, DxLinearGaugeModule, DxSliderModule,
    FormsModule,
    ErrorStateMatcher,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path:'customer', loadChildren:"./customer/customer.module#CustomerModule"},
      { path: 'device', loadChildren:"./device/device.module#DeviceModule"},
      { path: 'user', loadChildren:"./user/user.module#UserModule"},
      { path: 'location', loadChildren:"./location/location.module#LocationModule"},
      {path:'404', component:NotFoundComponent},
      {path: '500', component: InternalServerComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [EnvironmentUrlService, RepositoryService, ErrorHandService, DatePipe,
    {provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
platformBrowserDynamic().bootstrapModule(AppModule);