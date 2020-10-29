import { ComponentFixture, TestBed } from '@angular/core/testing';
import { addWardService } from 'src/app/services/addWard.service';
import { WardComponent } from './ward.component';

describe('WardComponent', () => {
  let component: WardComponent;
  let fixture: ComponentFixture<WardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WardComponent ],
      imports:[addWardService],
      providers:[addWardService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
