import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NurseHomeComponent } from './nurse-home/nurse-home.component';
import { AppRoutingModule } from '../app-routing.module';
import { NurseAddPatientComponent } from './nurse-add-patient/nurse-add-patient.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule } from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';



@NgModule({
  declarations: [NurseHomeComponent, NurseAddPatientComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatGridListModule
  ],
  exports:[NurseHomeComponent,NurseAddPatientComponent]

})
export class NurseModule { }
