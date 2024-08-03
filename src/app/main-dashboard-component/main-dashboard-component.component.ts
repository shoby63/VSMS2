import { Component } from '@angular/core';
import { AuthService } from '../auth-service.service';

@Component({
  selector: 'app-main-dashboard-component',
  templateUrl: './main-dashboard-component.component.html',
  styleUrl: './main-dashboard-component.component.css'
})
export class MainDashboardComponentComponent {
  activeCustomers: number = 120;
  totalVehicles: number = 80;
  totalServiceAdvisors: number = 15;
  constructor(private authService:AuthService){}
  onLogOut(){
    this.authService.logout();
  }
}
