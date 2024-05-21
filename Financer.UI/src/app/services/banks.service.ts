import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Bank, BankModelCreate } from "../models/bank";

@Injectable({
  providedIn: 'root'
})
export class BankService {
  private endpoint = endpoints.bank;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<Bank[]> {
    return this.apiService.get<Bank[]>(this.endpoint);
  }

  getById(id: number): Observable<Bank> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<Bank>(url);
  }

  create(product: BankModelCreate): Observable<Bank> {
    return this.apiService.post<Bank>(this.endpoint, product);
  }

  update(product: BankModelCreate, id: number): Observable<Bank> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<Bank>(url, product);
  }

  delete(id: number): Observable<Bank> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<Bank>(url);
  }

  getTableColumns(){
    return ['name','agency'];
  }

  getColumnNames(){
      return ['Bank', 'Agency'];
  }
}
