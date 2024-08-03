import { Component, EventEmitter, Input, Output } from '@angular/core';
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

  // @Input()
  // editRow!: (item:number) => void;
  @Output()
  editRow = new EventEmitter<number>();

  constructor() {}
  onEditRow(itemId: number) {
    this.editRow.emit(itemId);
  }
  deleteRow(itemId: number) {
    this.data = this.data.filter((item) => item.id !== itemId);
  }
}
