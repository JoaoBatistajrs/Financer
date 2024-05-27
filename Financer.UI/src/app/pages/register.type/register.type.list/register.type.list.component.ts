import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { RegisterTypeService } from '../../../services/registertype.service';
import { RegisterType } from '../../../models/registertype';
import { DatatableComponent } from '../../../shared/datatable/datatable.component';
import { RegisterTypeDialogComponent } from '../register.type.dialog/register.type.dialog.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation.dialog/confirmation.dialog.component';

@Component({
  selector: 'app-register-type-list',
  standalone: true,
  imports: [
    DatatableComponent,
    MatButtonModule,
    MatTooltipModule,
    MatIconModule,
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  templateUrl: './register.type.list.component.html',
  styleUrls: ['./register.type.list.component.scss']
})
export class RegisterTypeListComponent implements OnInit {
  tableColumns: string[] = [];
  columnNames: string[] = [];
  registerTypeData: RegisterType[] = [];
  name: string = '';

  constructor(
    private registerTypeService: RegisterTypeService,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.initializeTableColumns();
    this.refreshData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(RegisterTypeDialogComponent, {
      data: { name: this.name },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.createRegisterType(result);
      }
    });
  }

  edit(registerType: RegisterType): void {
    this.router.navigate(['edit-registerType', registerType.id]);
  }

  refreshData(): void {
    this.registerTypeService.getAll().subscribe(data => this.registerTypeData = data);
  }

  remove(registerType: RegisterType): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteRegisterType(registerType.id);
      }
    });
  }

  private initializeTableColumns(): void {
    this.tableColumns = this.registerTypeService.getTableColumns();
    this.columnNames = this.registerTypeService.getColumnNames();
  }

  private createRegisterType(registerType: RegisterType): void {
    this.registerTypeService.create(registerType).subscribe({
      next: () => this.showSnackBar('Register Type was created!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private deleteRegisterType(registerTypeId: number): void {
    this.registerTypeService.delete(registerTypeId).subscribe({
      next: () => this.showSnackBar('Register Type was deleted!'),
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
