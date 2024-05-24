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
import { RegisterType } from '../../../models/registertype';
import { RegisterTypeService } from '../../../services/registertype.service';

@Component({
  selector: 'app-register.type.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './register.type.list.component.html',
  styleUrl: './register.type.list.component.scss'
})
export class RegisterTypeListComponent {
  tableColumns!: string[];
  columnNames!: string[];
  registerTypeData!: RegisterType[];

  constructor(private registerTypeService: RegisterTypeService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.registerTypeService.getTableColumns();
    this.columnNames = this.registerTypeService.getColumnNames();
    // this.updateService.updated$.subscribe(() => {
    //   this.refreshData();
    // });
  }

  OnCreate(): void {
    this.router.navigate(['create-bank']);
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
