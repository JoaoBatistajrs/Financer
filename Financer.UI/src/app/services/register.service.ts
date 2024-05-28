import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Register, RegisterCreate } from "../models/register";

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private endpoint = endpoints.registers;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<Register[]> {
    return this.apiService.get<Register[]>(this.endpoint);
  }

  getById(id: number): Observable<Register> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<Register>(url);
  }

  create(product: RegisterCreate): Observable<RegisterCreate> {
    return this.apiService.post<RegisterCreate>(this.endpoint, product);
  }

  update(product: Register, id: number): Observable<Register> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<Register>(url, product);
  }

  delete(id: number): Observable<Register> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<Register>(url);
  }

  getTableColumns(){
    return ['description','date', 'amount', 'bankName', 'categoryName', 'registerTypeName'];
  }

  getColumnNames(){
      return ['Description', 'Date', 'Amount', 'Bank', 'Category', 'Type'];
  }
}
