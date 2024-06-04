import {Component, Inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ExpenseType, ExpenseTypeCreate } from '../../../models/expensetype';

@Component({
  selector: 'app-expense.type.dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
  templateUrl: './expense.type.dialog.component.html',
  styleUrl: './expense.type.dialog.component.scss'
})
export class ExpenseTypeDialogComponent {
  isEditMode: boolean;

  constructor(
    public dialogRef: MatDialogRef<ExpenseTypeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ExpenseTypeCreate,
  ) {
    this.isEditMode = (data as ExpenseType).id !== undefined;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    this.dialogRef.close(this.data);
  }

  isFormValid(): boolean {
    return this.data.name.trim() !== '';
  }
}

