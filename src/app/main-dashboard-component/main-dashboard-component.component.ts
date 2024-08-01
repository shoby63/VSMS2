import { Component } from '@angular/core';

@Component({
  selector: 'app-main-dashboard-component',
  templateUrl: './main-dashboard-component.component.html',
  styleUrl: './main-dashboard-component.component.css'
})
export class MainDashboardComponentComponent {
  activeCustomers: number = 120;
  totalVehicles: number = 80;
  totalServiceAdvisors: number = 15;
}
