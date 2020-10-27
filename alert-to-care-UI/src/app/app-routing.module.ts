import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin/admin-home/admin-home.component';
import { NurseListComponent } from './admin/nurse-list/nurse-list.component';
import { ProfileComponent } from './admin/profile/profile.component';
import { WardListComponent } from './admin/ward-list/ward-list.component';
import { WardComponent } from './admin/ward/ward.component';
import { HomeComponent } from './home/home.component';
import { NurseHomeComponent } from './nurse/nurse-home/nurse-home.component';
import {AuthGuardService} from './services/authRouteGuard.service'
import { NurseAddPatientComponent } from './nurse/nurse-add-patient/nurse-add-patient.component';
const routes: Routes = [

  {path:"",redirectTo:'home',pathMatch:'full'},

  {path:'home',component:HomeComponent},
  {path:'nurse/:userName',component:NurseHomeComponent},
    {path:'admin/:userName', canActivate:[AuthGuardService],component:AdminHomeComponent,children:[
      {path:'ward',component:WardComponent},{path:'profile',component:ProfileComponent},{path:'nurselist',component:NurseListComponent},{path:'wardlist',component:WardListComponent}
    ]},
    {path:'addpatient',component:NurseAddPatientComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
