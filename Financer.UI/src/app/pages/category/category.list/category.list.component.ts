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
import { ExpenseType } from '../../../models/expensetype';
import { Category, CategoryModelCreate } from '../../../models/category';
import { CategoryService } from '../../../services/category.service';
import { CategoryDialogComponent } from '../category.dialog/category.dialog.component';
import { ExpenseTypeService } from '../../../services/expensetype.service';
import { Console } from 'console';

@Component({
  selector: 'app-category.list',
  standalone: true,
  imports: [DatatableComponent, MatButtonModule, MatTooltipModule, MatIconModule, MatCardModule, ReactiveFormsModule],
  templateUrl: './category.list.component.html',
  styleUrl: './category.list.component.scss'
})
export class CategoryListComponent implements OnInit {
  tableColumns!: string[];
  columnNames!: string[];
  categoryData!: Category[];
  categoryCreate: CategoryModelCreate = this.initCategoryCreate();

  constructor(private categoryService: CategoryService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.initializeTableColumns();
    this.refreshData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(CategoryDialogComponent, {
      data: { ...this.categoryCreate },
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(result);
        this.createCategory(result);
      }
    });
  }


  edit(category: Category): void {
    const categoryId = category.id;
    this.router.navigate(['edit-expenseType', categoryId]);
  }

  refreshData(): void {
    this.categoryService.getAll().subscribe(data => this.categoryData = data);
  }

  remove(category: ExpenseType): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Are you sure you want to delete this record?'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteCategory(category.id);
      }
    });
  }

  private initializeTableColumns(): void {
    this.tableColumns = this.categoryService.getTableColumns();
    this.columnNames = this.categoryService.getColumnNames();
  }

  private createCategory(category: CategoryModelCreate): void {
    this.categoryService.create(category).subscribe({
      next: () => this.showSnackBar('Category was created!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private deleteCategory(categoryId: number): void {
    this.categoryService.delete(categoryId).subscribe({
      next: () => this.showSnackBar('Category was deleted!'),
      error: (err: any) => this.showSnackBar(err.message),
      complete: () => this.refreshData()
    });
  }

  private initCategoryCreate(): CategoryModelCreate {
    return {
      name: '',
      expenseTypeId: 0
    };
  }

  private showSnackBar(message: string): void {
    this.snackBar.open(message, '', {
      duration: 5000,
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });
  }
}
