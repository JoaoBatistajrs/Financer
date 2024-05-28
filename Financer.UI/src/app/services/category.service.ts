import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Category, CategoryModelCreate } from "../models/category";

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

  create(category: CategoryModelCreate): Observable<CategoryModelCreate> {
    return this.apiService.post<CategoryModelCreate>(this.endpoint, category);
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
    return ['name','expenseTypeName'];
  }

  getColumnNames(){
      return ['Name', 'Expense Type'];
  }
}
