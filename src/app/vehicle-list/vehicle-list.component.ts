import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';
import { VehicleService } from '../services/vehicle.service';
import { CreateDialogComponent } from '../create-dialog/create-dialog.component';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrl: './vehicle-list.component.css',
})
export class VehicleListComponent {
  constructor(
    public dialog: MatDialog,
    private vehicleService: VehicleService
  ) {}

  vehicleHeaders = ['Vehicle Name', 'Status', 'Service Advisor', 'Actions'];
  keys = ['name', 'status', 'serviceAdvisor'];
  vehicleList = [
    {
      id: 1,
      name: 'Toyota Camry',
      status: 'Serviced',
      serviceAdvisor: 'John Doe',
    },
    {
      id: 2,
      name: 'Honda Accord',
      status: 'Under Service',
      serviceAdvisor: 'Emily Smith',
    },
    {
      id: 3,
      name: 'Ford Mustang',
      status: 'Service Due',
      serviceAdvisor: 'Michael Johnson',
    },
    {
      id: 4,
      name: 'Chevrolet Silverado',
      status: 'Serviced',
      serviceAdvisor: 'Laura Davis',
    },
    {
      id: 5,
      name: 'BMW 3 Series',
      status: 'Under Service',
      serviceAdvisor: 'David Brown',
    },
    {
      id: 6,
      name: 'Audi A4',
      status: 'Service Due',
      serviceAdvisor: 'Sarah Wilson',
    },
  ];

  vehicleFormConfig = {
    title: 'Create New Vehicle',
    fields: [
      { name: 'name', label: 'Customer Name', type: 'text', required: true },
      { name: 'make', label: 'Make', type: 'text', required: true },
      { name: 'model', label: 'Model', type: 'text', required: true },
      { name: 'licensePlate', label: 'License Plate', type: 'text', required: true },
      {
        name: 'customer',
        label: 'Customer',
        type: 'select',
        options: [{ value: 1, label: 'Jane Smith' }, { value: 2, label: 'John Doe' }],
        required: true,
      },
      {
        name: 'serviceAdvisor',
        label: 'Service Advisor',
        type: 'select',
        options: [{ value: 101, label: 'Emily Clark' }, { value: 102, label: 'Michael Johnson' }],
        required: true,
      },
      {
        name: 'status',
        label: 'Status',
        type: 'select',
        options: [{ value: 'In Progress', label: 'In Progress' }, { value: 'Completed', label: 'Completed' }],
        required: true,
      },
    ],
  };

  // ngOnInit(): void {
  //   this.vehicleService.getVehicles().subscribe((data: any[]) => {
  //     this.vehicleList = data.map(vehicle => ({
  //       id: vehicle.id,
  //       name: `${vehicle.make} ${vehicle.model} (${vehicle.licensePlate})`,
  //       status: vehicle.serviceRecords.length > 0 ? vehicle.serviceRecords[0].status : 'Unknown',
  //       serviceAdvisor: vehicle.serviceAdvisor ? vehicle.serviceAdvisor.name : 'Unknown'
  //     }));
  //   });
  // }

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
    const dialogRef = this.dialog.open(UpdateDialogComponent, {
      data: item,
    });
    dialogRef.afterClosed().subscribe((result) => {
      // console.log(result);
    });
  }

  createDialog() {
    const dialogRef = this.dialog.open(CreateDialogComponent, {
      data: {formConfig: this.vehicleFormConfig}
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      this.vehicleList.push({
        id: 9,
        name: result.name,
        status: result.status,
        serviceAdvisor: result.serviceAdvisor,
      });
      // create vehicle
    });
  }
}
