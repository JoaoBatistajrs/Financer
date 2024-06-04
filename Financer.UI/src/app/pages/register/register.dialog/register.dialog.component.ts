import { Component, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Register, RegisterCreate } from '../../../models/register';
import { ExpenseType } from '../../../models/expensetype';
import { Bank } from '../../../models/bank';
import { Category } from '../../../models/category';
import { BankService } from '../../../services/banks.service';
import { CategoryService } from '../../../services/category.service';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { RegisterTypeService } from '../../../services/registertype.service';
import { provideNativeDateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-register.dialog',
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
    MatSelectModule,
    MatDatepickerModule
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './register.dialog.component.html',
  styleUrl: './register.dialog.component.scss'
})
export class RegisterDialogComponent implements OnInit {

  registerTypes: ExpenseType[] = [];
  banks: Bank[] = [];
  categories: Category[] = [];
  isEditMode: boolean;

  constructor(
    public dialogRef: MatDialogRef<RegisterDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RegisterCreate,
    private registerTypeService: RegisterTypeService,
    private bankService: BankService,
    private categoryService: CategoryService,
  ) {
    this.isEditMode = (data as Register).id !== undefined;
  }

  ngOnInit(): void {
    this.loadSelectFields();
  }

  loadSelectFields(): void {
    this.registerTypeService.getAll().subscribe(data => this.registerTypes = data);
    this.categoryService.getAll().subscribe(data => this.categories = data);
    this.bankService.getAll().subscribe(data => this.banks = data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    this.dialogRef.close(this.data);
  }

  isFormValid(): boolean {
    return this.data.description.trim() !== '' && this.data.amount > 0;
  }
}
