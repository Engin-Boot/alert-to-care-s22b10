import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WardComponent } from './ward/ward.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  declarations: [WardComponent, AdminHomeComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports:[AdminHomeComponent]
})
export class AdminModule { }
