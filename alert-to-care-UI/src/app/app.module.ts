import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { AdminModule } from './admin/admin.module';
import { NurseModule } from './nurse/nurse.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    NurseModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
