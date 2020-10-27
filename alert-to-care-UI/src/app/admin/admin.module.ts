import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WardComponent } from './ward/ward.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AppRoutingModule } from '../app-routing.module';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule } from '@angular/forms';
import { NurseListComponent } from './nurse-list/nurse-list.component';
import { WardListComponent } from './ward-list/ward-list.component';
import { getService } from '../services/getUsers.service';
import { NavbarComponent } from './navbar/navbar.component';
import { addNurseService } from '../services/addNurse.service';
import {addWardService} from '../services/addWard.service'


@NgModule({
  declarations: [WardComponent, AdminHomeComponent, ProfileComponent, NurseListComponent, WardListComponent, NavbarComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    FormsModule,
  
  ],
  exports:[AdminHomeComponent],
  providers:[{provide:getService,useClass:getService},{provide:addNurseService,useClass:addNurseService},{provide:addWardService,useClass:addWardService}]
})
export class AdminModule { }
