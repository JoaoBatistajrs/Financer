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

import { Router } from '@angular/router';
import { Register, RegisterCreate } from '../../../models/register';
import { RegisterService } from '../../../services/register.service';
import { RegisterDialogComponent } from '../register.dialog/register.dialog.component';

@Component({
  selector: 'app-register.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './register.list.component.html',
  styleUrl: './register.list.component.scss'
})
export class RegisterListComponent implements OnInit {
  tableColumns!: string[];
  columnNames!: string[];
  registerData!: Register[];
  registerCreate: RegisterCreate = this.initRegisterCreate();

  constructor(private registerService: RegisterService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.initializeTableColumns();
    this.refreshData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(RegisterDialogComponent, {
      data: { ...this.registerCreate },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.createRegister(result);
      }
    });
  }

  onEdit(register: Register): void {
    const dialogRef = this.dialog.open(RegisterDialogComponent, {
      data: { ...register },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updateRegister(result);
      }
    });
  }

  refreshData(): void {
    this.registerService.getAll().subscribe(data => this.registerData = data);
  }

  remove(register: Register): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteRegister(register.id);
      }
    });
  }

  private initRegisterCreate(): RegisterCreate {
    return {
      description: '',
      date: new Date(),
      bankId: 0,
      categoryId: 0,
      amount: 0,
      registerTypeId: 0,
      bankName: '',
      categoryName: '',
      registerTypeName: '',
      id: 0
    };
  }

  private createRegister(register: RegisterCreate): void {
    this.registerService.create(register).subscribe({
      next: () => this.showSnackBar('Register was created!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private updateRegister(register: Register): void {
    this.registerService.update(register, register.id,).subscribe({
      next: () => this.showSnackBar('Expense Type was updated!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private initializeTableColumns(): void {
    this.tableColumns = this.registerService.getTableColumns();
    this.columnNames = this.registerService.getColumnNames();
  }

  private deleteRegister(registerId: number): void {
    this.registerService.delete(registerId).subscribe({
      next: () => this.showSnackBar('Register was deleted!'),
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
