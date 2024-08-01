import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainDashboardComponentComponent } from './main-dashboard-component.component';

describe('MainDashboardComponentComponent', () => {
  let component: MainDashboardComponentComponent;
  let fixture: ComponentFixture<MainDashboardComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MainDashboardComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainDashboardComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
