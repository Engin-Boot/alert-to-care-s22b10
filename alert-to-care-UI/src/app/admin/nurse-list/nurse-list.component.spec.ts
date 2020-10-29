import { ComponentFixture, TestBed } from '@angular/core/testing';
import { getService } from 'src/app/services/getUsers.service';
import { Users } from 'src/app/users';
import { NurseListComponent } from './nurse-list.component';

describe('NurseListComponent', () => {
  let component: NurseListComponent;
  let fixture: ComponentFixture<NurseListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NurseListComponent ],
      imports:[getService, Users ],
      providers:[getService, Users ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NurseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
