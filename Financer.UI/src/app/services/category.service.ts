import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Bank, BankModelCreate } from "../models/bank";
import { Category } from "../models/category";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private endpoint = endpoints.bank;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<Category[]> {
    return this.apiService.get<Category[]>(this.endpoint);
  }

  getById(id: number): Observable<Category> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<Category>(url);
  }

  create(product: Category): Observable<Category> {
    return this.apiService.post<Category>(this.endpoint, product);
  }

  update(product: Category, id: number): Observable<Category> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<Category>(url, product);
  }

  delete(id: number): Observable<Category> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<Category>(url);
  }

  getTableColumns(){
    return ['name','expenseType'];
  }

  getColumnNames(){
      return ['Name', 'Expense Type'];
  }
}
