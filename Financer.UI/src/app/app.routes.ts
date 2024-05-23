import { ExpenseTypeListComponent } from './pages/expense.type/expense.type.list/expense.type.list.component';
import { Routes } from '@angular/router';
import { BankListComponent } from './pages/bank/bank.list/bank.list.component';
import { RegisterListComponent } from './pages/register/register.list/register.list.component';
import { CategoryListComponent } from './pages/category/category.list/category.list.component';
import { RegisterTypeListComponent } from './pages/register.type/register.type.list/register.type.list.component';

export const routes: Routes = [
  { path: 'bank', component:  BankListComponent },
  { path: 'register', component:  RegisterListComponent },
  { path: 'expense', component:  ExpenseTypeListComponent },
  { path: 'category', component:  CategoryListComponent },
  { path: 'register-type', component:  RegisterTypeListComponent },
];
