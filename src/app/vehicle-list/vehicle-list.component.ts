import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrl: './vehicle-list.component.css'
})
export class VehicleListComponent {


  constructor(public dialog: MatDialog) {}
  
  vehicleHeaders = [
    'Vehicle Name',
    'Status',
    'Service Advisor',
    'Actions'
  ];
  keys = ['name', 'status', 'serviceAdvisor'];
  vehicleList = [
    {
      id: 1,
      name: 'Vehicle 1',
      status: 'Serviced',
      serviceAdvisor:'Advisor 1'
    },
    {
      id: 2,
      name: 'Vehicle 2',
      status: 'Under Service',
      serviceAdvisor:'Advisor 2'
    },
    {
      id: 3,
      name: 'Vehicle 3',
      status: 'Service Due',
      serviceAdvisor:'Advisor 3'
    },
  ];

  updateVehicle(vehicle: any) {
    console.log('Updating vehicle:', vehicle);
  }

  showDetails(vehicle: any) {
    console.log('Showing details for vehicle:', vehicle);
  }

  scheduleService(vehicle: any) {
    console.log('Scheduling service for vehicle:', vehicle);
  }


  openDialog(itemId: number) {
    const item = this.vehicleList.find((item) => item.id === itemId);
    if(item) {
      this.dialog.open(UpdateDialogComponent, {
        data: item,
      });
    }
    else{
      alert('item not found');
    }
  }
}
