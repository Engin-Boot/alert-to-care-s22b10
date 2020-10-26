import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { AdminModule } from './admin/admin.module';
import { NurseModule } from './nurse/nurse.module';
import { LoggerService } from './services/logger.service';
import { FormsModule } from '@angular/forms';
import { AccountService } from './services/account.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthGuardService } from './services/authRouteGuard.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientServiceService } from './services/http-client-service.service';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    NurseModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [{provide:'logger',useClass:LoggerService},
  {provide:'apiBaseAddress',useValue:"http://localhost:64868"},
{provide:AccountService,useClass:AccountService},{provide:AuthGuardService,useClass:AuthGuardService},{provide:HttpClientServiceService,useClass:HttpClientServiceService}],
  bootstrap: [AppComponent]
})
export class AppModule { }
