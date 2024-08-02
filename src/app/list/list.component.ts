import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css',
})
export class ListComponent {
  @Input()
  data!: any[];

  @Input()
  headers!: any[];

  @Input()
  keys: string[] = [];

  @Input()
  editRow!: (item:number) => void;

  constructor() {}

  deleteRow(itemId: number) {
    this.data = this.data.filter((item) => item.id !== itemId);
  }
}
