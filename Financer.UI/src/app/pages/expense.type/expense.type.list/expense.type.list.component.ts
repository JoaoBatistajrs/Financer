import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

import { ExpenseTypeService } from '../../../services/expensetype.service';
import { ExpenseType } from '../../../models/expensetype';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { ExpenseTypeDialogComponent } from '../expense.type.dialog/expense.type.dialog.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation.dialog/confirmation.dialog.component';

@Component({
  selector: 'app-expense-type-list',
  standalone: true,
  imports: [
    DatatableComponent,
    MatButtonModule,
    MatTooltipModule,
    MatIconModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  templateUrl: './expense.type.list.component.html',
  styleUrls: ['./expense.type.list.component.scss']
})
export class ExpenseTypeListComponent implements OnInit {
  tableColumns: string[] = [];
  columnNames: string[] = [];
  expenseTypeData: ExpenseType[] = [];
  name: string = '';

  constructor(
    private expenseTypeService: ExpenseTypeService,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.initializeTableColumns();
    this.refreshData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(ExpenseTypeDialogComponent, {
      data: { name: this.name },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.createExpenseType(result);
      }
    });
  }

  onEdit(expenseType: ExpenseType): void {
    const dialogRef = this.dialog.open(ExpenseTypeDialogComponent, {
      data: { ...expenseType },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updateExpenseType(result);
      }
    });
  }

  refreshData(): void {
    this.expenseTypeService.getAll().subscribe(data => this.expenseTypeData = data);
  }

  remove(expenseType: ExpenseType): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteExpenseType(expenseType.id);
      }
    });
  }

  private initializeTableColumns(): void {
    this.tableColumns = this.expenseTypeService.getTableColumns();
    this.columnNames = this.expenseTypeService.getColumnNames();
  }

  private createExpenseType(expenseType: ExpenseType): void {
    this.expenseTypeService.create(expenseType).subscribe({
      next: () => this.showSnackBar('Expense Type was created!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private updateExpenseType(expenseType: ExpenseType): void {
    this.expenseTypeService.update(expenseType, expenseType.id,).subscribe({
      next: () => this.showSnackBar('Expense Type was updated!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private deleteExpenseType(expenseTypeId: number): void {
    this.expenseTypeService.delete(expenseTypeId).subscribe({
      next: () => this.showSnackBar('Expense Type was deleted!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private showSnackBar(message: string): void {
    this.snackBar.open(message, '', {
      duration: 5000,
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });
  }
}
