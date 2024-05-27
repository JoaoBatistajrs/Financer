import {Component, Inject, OnInit} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { CategoryModelCreate } from '../../../models/category';
import { ExpenseTypeService } from '../../../services/expensetype.service';
import { ExpenseType } from '../../../models/expensetype';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category.dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatSelectModule
  ],
  templateUrl: './category.dialog.component.html',
  styleUrl: './category.dialog.component.scss'
})
export class CategoryDialogComponent implements OnInit {
  expenseTypes: ExpenseType[] = [];

  constructor(
    public dialogRef: MatDialogRef<CategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CategoryModelCreate,
    private expenseTypeService: ExpenseTypeService
  ) {}

  ngOnInit(): void {
    this.loadExpenseTypes();
  }

  loadExpenseTypes(): void {
    this.expenseTypeService.getAll().subscribe(data => this.expenseTypes = data);
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
