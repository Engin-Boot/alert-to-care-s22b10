import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Wards } from 'src/app/ward';
import { WardListComponent } from './ward-list.component';

describe('WardListComponent', () => {
  let component: WardListComponent;
  let fixture: ComponentFixture<WardListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WardListComponent ],
      imports:[Wards],
      providers:[Wards]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
