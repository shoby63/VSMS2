import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceRecordDetailComponent } from './service-record-detail.component';

describe('ServiceRecordDetailComponent', () => {
  let component: ServiceRecordDetailComponent;
  let fixture: ComponentFixture<ServiceRecordDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ServiceRecordDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceRecordDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
