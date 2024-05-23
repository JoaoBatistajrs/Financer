import { ConfirmationDialogComponent } from './../../../shared/confirmation.dialog/confirmation.dialog.component';
import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { Router } from '@angular/router';
import { ExpenseType } from '../../../models/expensetype';
import { ExpenseTypeService } from '../../../services/expensetype.service';


@Component({
  selector: 'app-expense.type.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './expense.type.list.component.html',
  styleUrl: './expense.type.list.component.scss'
})
export class ExpenseTypeListComponent {
  tableColumns!: string[];
  columnNames!: string[];
  expenseTypeData!: ExpenseType[];

  constructor(private expenseTypeService: ExpenseTypeService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.expenseTypeService.getTableColumns();
    this.columnNames = this.expenseTypeService.getColumnNames();
    // this.updateService.updated$.subscribe(() => {
    //   this.refreshData();
    // });
  }

  OnCreate(): void {
    this.router.navigate(['create-expenseType']);
  }

  edit(bank: ExpenseType): void {
    const bankId = bank.id;
    this.router.navigate(['edit-expenseType', bankId]);
  }

  refreshData(): void {
    this.expenseTypeService.getAll().subscribe(data => this.expenseTypeData = data);
  }

  remove(bank: ExpenseType): void {
    const bankId = bank.id;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.expenseTypeService.delete(bankId).subscribe(
          {
            next: () => {
              this.snackBar.open('Manufacturer was deleted!', '', {
                duration: 5000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.refreshData();
            },
            error: (err: any) => {
              this.snackBar.open(err.message, '', {
                duration: 5000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
            }
          });
      }
    });
  }

}

