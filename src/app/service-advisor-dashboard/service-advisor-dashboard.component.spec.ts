import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceAdvisorDashboardComponent } from './service-advisor-dashboard.component';

describe('ServiceAdvisorDashboardComponent', () => {
  let component: ServiceAdvisorDashboardComponent;
  let fixture: ComponentFixture<ServiceAdvisorDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ServiceAdvisorDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceAdvisorDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
