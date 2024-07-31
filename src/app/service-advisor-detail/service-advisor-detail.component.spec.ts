import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceAdvisorDetailComponent } from './service-advisor-detail.component';

describe('ServiceAdvisorDetailComponent', () => {
  let component: ServiceAdvisorDetailComponent;
  let fixture: ComponentFixture<ServiceAdvisorDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ServiceAdvisorDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceAdvisorDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
