import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatCardModule } from '@angular/material/card';
import {
  MatSlideToggleModule,
  MatSlideToggle,
} from '@angular/material/slide-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';
import { ServiceRecordListComponent } from './service-record-list/service-record-list.component';
import { ServiceRecordDetailComponent } from './service-record-detail/service-record-detail.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { ServiceAdvisorDashboardComponent } from './service-advisor-dashboard/service-advisor-dashboard.component';
import { ServiceAdvisorListComponent } from './service-advisor-list/service-advisor-list.component';
import { ServiceAdvisorDetailComponent } from './service-advisor-detail/service-advisor-detail.component';
import { WorkItemListComponent } from './work-item-list/work-item-list.component';
import { WorkItemDetailComponent } from './work-item-detail/work-item-detail.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './auth.guard';
import { MainDashboardComponentComponent } from './main-dashboard-component/main-dashboard-component.component';
import { ListComponent } from './list/list.component';
import { UpdateDialogComponent } from './update-dialog/update-dialog.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    AdmindashboardComponent,
    VehicleListComponent,
    VehicleDetailComponent,
    ServiceRecordListComponent,
    ServiceRecordDetailComponent,
    CustomerListComponent,
    CustomerDetailComponent,
    ServiceAdvisorDashboardComponent,
    ServiceAdvisorListComponent,
    ServiceAdvisorDetailComponent,
    WorkItemListComponent,
    WorkItemDetailComponent,
    MainDashboardComponentComponent,
    ListComponent,
    UpdateDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSlideToggleModule,
    FormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatDialogModule,
    MatCardModule,
    ReactiveFormsModule,
  ],
  providers: [AuthGuard, provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
