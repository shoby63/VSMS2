import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { ServiceAdvisorDashboardComponent } from './service-advisor-dashboard/service-advisor-dashboard.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';
import { ServiceRecordListComponent } from './service-record-list/service-record-list.component';
import { ServiceRecordDetailComponent } from './service-record-detail/service-record-detail.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { ServiceAdvisorListComponent } from './service-advisor-list/service-advisor-list.component';
import { ServiceAdvisorDetailComponent } from './service-advisor-detail/service-advisor-detail.component';
import { WorkItemListComponent } from './work-item-list/work-item-list.component';
import { WorkItemDetailComponent } from './work-item-detail/work-item-detail.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard],data: { expectedRole: 'admin' } },
  { path: 'admin', component: AdmindashboardComponent, canActivate: [AuthGuard], data: { expectedRole: 'admin' },children: [
      { path: 'vehicles', component: VehicleListComponent },
      { path: 'vehicles/:id', component: VehicleDetailComponent },
      { path: 'service-records', component: ServiceRecordListComponent },
      { path: 'service-records/:id', component: ServiceRecordDetailComponent },
      { path: 'customers', component: CustomerListComponent },
      { path: 'customers/:id', component: CustomerDetailComponent },
      { path: 'service-advisors', component: ServiceAdvisorListComponent },
      { path: 'service-advisors/:id', component: ServiceAdvisorDetailComponent },
      { path: 'work-items', component: WorkItemListComponent },
      { path: 'work-items/:id', component: WorkItemDetailComponent }
    ]
  },
  { path: 'service-advisor', component: ServiceAdvisorDashboardComponent, canActivate: [AuthGuard], children: [
      { path: 'vehicles', component: VehicleListComponent },
      { path: 'vehicles/:id', component: VehicleDetailComponent },
      { path: 'service-records', component: ServiceRecordListComponent },
      { path: 'service-records/:id', component: ServiceRecordDetailComponent },
      { path: 'customers', component: CustomerListComponent },
      { path: 'customers/:id', component: CustomerDetailComponent },
      { path: 'work-items', component: WorkItemListComponent },
      { path: 'work-items/:id', component: WorkItemDetailComponent }
    ]
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
