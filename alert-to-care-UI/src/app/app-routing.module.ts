import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin/admin-home/admin-home.component';
import { WardComponent } from './admin/ward/ward.component';
import { HomeComponent } from './home/home.component';
import { NurseAddPatientComponent } from './nurse/nurse-add-patient/nurse-add-patient.component';
import { NurseHomeComponent } from './nurse/nurse-home/nurse-home.component';

const routes: Routes = [

  {path:"",redirectTo:'home',pathMatch:'full'},

  {path:'home',component:HomeComponent},
  {path:'nurse',component:NurseHomeComponent},
  {path:'addpatient',component:NurseAddPatientComponent},
  {path:'admin',component:AdminHomeComponent,children:[
      {path:'ward',component:WardComponent}
  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
