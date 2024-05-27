import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Category } from "../models/category";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private endpoint = endpoints.categories;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<Category[]> {
    return this.apiService.get<Category[]>(this.endpoint);
  }

  getById(id: number): Observable<Category> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<Category>(url);
  }

  create(category: Category): Observable<Category> {
    return this.apiService.post<Category>(this.endpoint, category);
  }

  update(category: Category, id: number): Observable<Category> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<Category>(url, category);
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
