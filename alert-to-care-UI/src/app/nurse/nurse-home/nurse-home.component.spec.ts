import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import {HttpClientServiceService,BedDetails} from "../../services/http-client-service.service";
import { NurseHomeComponent } from './nurse-home.component';

describe('NurseHomeComponent', () => {
  let component: NurseHomeComponent;
  let fixture: ComponentFixture<NurseHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NurseHomeComponent ],
      imports:[
        ActivatedRoute,
        Router,
        HttpClientServiceService,
        BedDetails
      ],
      providers:[
        ActivatedRoute,
        Router,
        HttpClientServiceService,
        BedDetails
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NurseHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
