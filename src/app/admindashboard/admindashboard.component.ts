import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.css'
})
export class AdmindashboardComponent {
  activeCustomers: number = 120;
  totalVehicles: number = 80;
  totalServiceAdvisors: number = 15;
  totalWorkItems: number = 50;
  cards = [
    { title: 'Total Service Advisors', count: 15 },
    { title: 'Vehicles', count: 40 },
    {
      title:'Active Customers',count:10
    }
    // Add more cards as needed
  ];
  constructor(private router: Router){}

  ngOnInit(): void {}
  logout() {
    this.router.navigate(['/login']);
  }
}
