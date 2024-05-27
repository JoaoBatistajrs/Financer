import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BankService } from '../../../services/banks.service';
import { Bank } from '../../../models/bank';
import { BankModelCreate } from '../../../models/bank';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { BankDialogComponent } from '../bank.dialog/bank.dialog.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation.dialog/confirmation.dialog.component';

@Component({
  selector: 'app-bank-list',
  standalone: true,
  imports: [
    DatatableComponent,
    MatButtonModule,
    MatTooltipModule,
    MatIconModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  templateUrl: './bank.list.component.html',
  styleUrls: ['./bank.list.component.scss']
})
export class BankListComponent implements OnInit {
  tableColumns: string[] = [];
  columnNames: string[] = [];
  bankData: Bank[] = [];
  bankCreate: BankModelCreate = this.initBankCreate();

  constructor(
    private bankService: BankService,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.initializeTableColumns();
    this.refreshData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(BankDialogComponent, {
      data: { ...this.bankCreate },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.createBank(result);
      }
    });
  }

  edit(bank: Bank): void {
    this.router.navigate(['edit-bank', bank.id]);
  }

  refreshData(): void {
    this.bankService.getAll().subscribe(data => this.bankData = data);
  }

  remove(bank: Bank): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteBank(bank.id);
      }
    });
  }

  private initBankCreate(): BankModelCreate {
    return {
      name: '',
      accountBalance: 0,
      accountNumber: '',
      agency: ''
    };
  }

  private initializeTableColumns(): void {
    this.tableColumns = this.bankService.getTableColumns();
    this.columnNames = this.bankService.getColumnNames();
  }

  private createBank(bank: BankModelCreate): void {
    this.bankService.create(bank).subscribe({
      next: () => this.showSnackBar('Bank Account was created!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private deleteBank(bankId: number): void {
    this.bankService.delete(bankId).subscribe({
      next: () => this.showSnackBar('Bank Account was deleted!'),
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
