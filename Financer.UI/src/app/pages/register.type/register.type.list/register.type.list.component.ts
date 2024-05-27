import { ConfirmationDialogComponent } from './../../../shared/confirmation.dialog/confirmation.dialog.component';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { Router } from '@angular/router';
import { RegisterType } from '../../../models/registertype';
import { RegisterTypeService } from '../../../services/registertype.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RegisterTypeDialogComponent } from '../register.type.dialog/register.type.dialog.component';

@Component({
  selector: 'app-register.type.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
  templateUrl: './register.type.list.component.html',
  styleUrl: './register.type.list.component.scss'
})
export class RegisterTypeListComponent implements OnInit {
  tableColumns!: string[];
  columnNames!: string[];
  registerTypeData!: RegisterType[];
  name!: string;

  constructor(private registerTypeService: RegisterTypeService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.registerTypeService.getTableColumns();
    this.columnNames = this.registerTypeService.getColumnNames();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(RegisterTypeDialogComponent, {
      data: {name: this.name},
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.registerTypeService.create(result).subscribe(
          {
            next: () => {
              this.snackBar.open('Register Type was created!', '', {
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

  edit(registerType: RegisterType): void {
    const registerTypeId = registerType.id;
    this.router.navigate(['edit-bank', registerTypeId]);
  }

  refreshData(): void {
    this.registerTypeService.getAll().subscribe(data => this.registerTypeData = data);
  }

  remove(bank: RegisterType): void {
    const registerTypeId = bank.id;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.registerTypeService.delete(registerTypeId).subscribe(
          {
            next: () => {
              this.snackBar.open('Register Type was deleted!', '', {
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
