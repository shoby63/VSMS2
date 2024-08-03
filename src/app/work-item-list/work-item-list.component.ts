import { Component } from '@angular/core';
interface WorkItem {
  Name: string;
  Price: number;
}
@Component({
  selector: 'app-work-item-list',
  templateUrl: './work-item-list.component.html',
  styleUrl: './work-item-list.component.css'
})

export class WorkItemListComponent {
  workItems: WorkItem[] = [
    { Name: 'Oil Change', Price: 39.99 },
    { Name: 'Tire Rotation', Price: 29.99 },
    { Name: 'Brake Inspection', Price: 49.99 },
    { Name: 'Battery Replacement', Price: 89.99 },
    { Name: 'Air Filter Replacement', Price: 24.99 },
    { Name: 'Wheel Alignment', Price: 79.99 },
    { Name: 'Engine Diagnostics', Price: 99.99 },
    { Name: 'Transmission Service', Price: 199.99 },
    { Name: 'AC Service', Price: 129.99 },
    { Name: 'Full Car Inspection', Price: 149.99 },
    { Name: 'Transmission Service', Price: 199.99 },
    { Name: 'AC Service', Price: 129.99 },
    { Name: 'Full Car Inspection', Price: 149.99 },
  ];

  updateWorkItem(item: WorkItem) {
    // Handle the update action here
    console.log('Update work item:', item);
  }

  deleteWorkItem(item: WorkItem) {
    // Handle the delete action here
    this.workItems = this.workItems.filter(i => i !== item);
    console.log('Deleted work item:', item);
  }
}
