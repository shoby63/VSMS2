import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceAdvisorListComponent } from './service-advisor-list.component';

describe('ServiceAdvisorListComponent', () => {
  let component: ServiceAdvisorListComponent;
  let fixture: ComponentFixture<ServiceAdvisorListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ServiceAdvisorListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceAdvisorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
