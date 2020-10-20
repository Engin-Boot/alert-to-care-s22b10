import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NurseHomeComponent } from './nurse-home/nurse-home.component';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  declarations: [NurseHomeComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports:[NurseHomeComponent]

})
export class NurseModule { }
