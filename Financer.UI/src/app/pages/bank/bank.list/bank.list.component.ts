import { ConfirmationDialogComponent } from './../../../shared/confirmation.dialog/confirmation.dialog.component';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { Bank } from '../../../models/bank';
import { BankService } from '../../../services/banks.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bank.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './bank.list.component.html',
  styleUrl: './bank.list.component.scss'
})
export class BankListComponent implements OnInit {
  tableColumns!: string[];
  columnNames!: string[];
  bankData!: Bank[];

  constructor(private bankService: BankService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.bankService.getTableColumns();
    this.columnNames = this.bankService.getColumnNames();
    // this.updateService.updated$.subscribe(() => {
    //   this.refreshData();
    // });
  }

  OnCreate(): void {
    this.router.navigate(['create-bank']);
  }

  edit(bank: Bank): void {
    const bankId = bank.id;
    this.router.navigate(['edit-bank', bankId]);
  }

  refreshData(): void {
    this.bankService.getAll().subscribe(data => this.bankData = data);
  }

  remove(bank: Bank): void {
    const bankId = bank.id;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.bankService.delete(bankId).subscribe(
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
