import { Component, Inject, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-dialog',
  templateUrl: './create-dialog.component.html',
  styleUrls: ['./create-dialog.component.css'],
})
export class CreateDialogComponent {
  formGroup!: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<CreateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.formGroup = this.fb.group({});
    this.data.formConfig.fields.forEach((field: any) => {
      const validators = field.required ? [Validators.required] : [];
      this.formGroup.addControl(field.name, this.fb.control(field.value || '', validators));
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    this.dialogRef.close(this.formGroup.getRawValue());
  }
}
