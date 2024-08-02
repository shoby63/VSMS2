import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-update-dialog',
  templateUrl: './update-dialog.component.html',
  styleUrl: './update-dialog.component.css',
})
export class UpdateDialogComponent {
  editVehicleForm: FormGroup;

  statusOptions: string[] = ['Serviced', 'Under Service', 'Service Due'];
  serviceAdvisors: string[] = ['Advisor 1', 'Advisor 2', 'Advisor 3'];

  constructor(
    public dialogRef: MatDialogRef<UpdateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {
    this.editVehicleForm = this.fb.group({
      name: [data.name, Validators.required],
      serviceAdvisor: [data.serviceAdvisor, Validators.required],
      status: [data.status, Validators.required],
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    this.dialogRef.close(this.data);
    this.data.name = this.editVehicleForm.get('name')?.value;
    this.data.status = this.editVehicleForm.get('status')?.value;
    this.data.serviceAdvisor =
      this.editVehicleForm.get('serviceAdvisor')?.value;
  }
}
