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
import { Category } from '../../../models/category';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-category.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './category.list.component.html',
  styleUrl: './category.list.component.scss'
})
export class CategoryListComponent {
  tableColumns!: string[];
  columnNames!: string[];
  categoryData!: Category[];

  constructor(private categoryService: CategoryService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.refreshData();
    this.tableColumns = this.categoryService.getTableColumns();
    this.columnNames = this.categoryService.getColumnNames();
    // this.updateService.updated$.subscribe(() => {
    //   this.refreshData();
    // });
  }

  OnCreate(): void {
    this.router.navigate(['create-expenseType']);
  }

  edit(category: Category): void {
    const categoryId = category.id;
    this.router.navigate(['edit-expenseType', categoryId]);
  }

  refreshData(): void {
    this.categoryService.getAll().subscribe(data => this.categoryData = data);
  }

  remove(category: ExpenseType): void {
    const categoryId = category.id;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.categoryService.delete(categoryId).subscribe(
          {
            next: () => {
              this.snackBar.open('Category was deleted!', '', {
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
