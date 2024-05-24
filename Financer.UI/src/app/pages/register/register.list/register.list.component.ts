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
import { Register } from '../../../models/register';
import { RegisterService } from '../../../services/register.service';

@Component({
  selector: 'app-register.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './register.list.component.html',
  styleUrl: './register.list.component.scss'
})
export class RegisterListComponent {
  tableColumns!: string[];
  columnNames!: string[];
  registerData!: Register[];

  constructor(private registerService: RegisterService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.registerService.getTableColumns();
    this.columnNames = this.registerService.getColumnNames();
    // this.updateService.updated$.subscribe(() => {
    //   this.refreshData();
    // });
  }

  OnCreate(): void {
    this.router.navigate(['create-bank']);
  }

  edit(register: Register): void {
    const registerId = register.id;
    this.router.navigate(['edit-bank', registerId]);
  }

  refreshData(): void {
    this.registerService.getAll().subscribe(data => this.registerData = data);
  }

  remove(register: Register): void {
    const registerId = register.id;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.registerService.delete(registerId).subscribe(
          {
            next: () => {
              this.snackBar.open('Register was deleted!', '', {
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
