import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { RegisterType } from "../models/registertype";
import { ExpenseType } from "../models/expensetype";

@Injectable({
  providedIn: 'root'
})
export class ExpenseTypeService {
  private endpoint = endpoints.expenseType;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<ExpenseType[]> {
    return this.apiService.get<ExpenseType[]>(this.endpoint);
  }

  getById(id: number): Observable<ExpenseType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<ExpenseType>(url);
  }

  create(registerType: ExpenseType): Observable<ExpenseType> {
    return this.apiService.post<ExpenseType>(this.endpoint, registerType);
  }

  update(registerType: ExpenseType, id: number): Observable<ExpenseType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<ExpenseType>(url, registerType);
  }

  delete(id: number): Observable<ExpenseType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<ExpenseType>(url);
  }

  getTableColumns(){
    return ['name'];
  }

  getColumnNames(){
      return ['Expense Type Name'];
  }
}
