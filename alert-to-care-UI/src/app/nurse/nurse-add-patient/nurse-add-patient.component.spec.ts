import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, FormGroup ,NgForm,Validators} from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { HttpClientServiceService } from 'src/app/services/http-client-service.service';
import { NurseAddPatientComponent } from './nurse-add-patient.component';

describe('NurseAddPatientComponent', () => {
  let component: NurseAddPatientComponent;
  let fixture: ComponentFixture<NurseAddPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NurseAddPatientComponent ],
      imports:[ FormBuilder, FormGroup ,NgForm,Validators,ActivatedRoute,Router,HttpClientServiceService],
      providers:[FormBuilder, FormGroup ,NgForm,Validators,ActivatedRoute,Router,HttpClientServiceService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NurseAddPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
