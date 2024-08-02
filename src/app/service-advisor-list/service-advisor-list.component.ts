import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';

@Component({
  selector: 'app-service-advisor-list',
  templateUrl: './service-advisor-list.component.html',
  styleUrl: './service-advisor-list.component.css'
})
export class ServiceAdvisorListComponent implements OnInit {
 serviceAdvisors:any=[{
  id:1,
  name:"John Doe",
  status:"Active"
 },
 {
  id:2,
  name:"John 1",
  status:"InActive"
 },
 {
  id:3,
  name:"John 2",
  status:"Active"
 }];
 serviceHeaders=['Name', 'Status', 'Actions'];

 keys = ['name', 'status'];

 constructor(private dialog: MatDialog) {}

ngOnInit():void{
  this.serviceAdvisors=[{
    id:1,
    name:"John Doe",
    status:"Active"
   },
   {
    id:2,
    name:"John 1",
    status:"InActive"
   },
   {
    id:3,
    name:"John 2",
    status:"Active"
   }];
}
 openDialog(itemId: number) {
  console.log(this.serviceAdvisors)
  const item = this.serviceAdvisors?.find((item: { id: number; }) => item.id === itemId);
  console.log(item)
  if(item) {
    this.dialog.open(UpdateDialogComponent, {
      data: item,
    });
  }
}
}
