import { Injectable, inject } from "@angular/core";
import { Observable, map } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { Bank, BankModelCreate } from "../models/bank";

@Injectable({
  providedIn: 'root'
})
export class BankService {
  private readonly apiService = inject(ApiService);
  private endpoint = endpoints.bank;

  getAll(): Observable<Bank[]> {
    return this.apiService.get(this.endpoint);
  }

  getById(id: number): Observable<Bank> {
    const url = `${this.endpoint}/${id}`;

    return this.apiService.get<Bank>(url).pipe(
      map((product: Bank) => ({
        ...product,
      }))
    );
  }

  create(product: BankModelCreate): Observable<BankModelCreate>{
    return this.apiService.post<BankModelCreate>(this.endpoint, product);
  }

  update(product: BankModelCreate, id: number): Observable<BankModelCreate>{
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<BankModelCreate>(url, product);
  }

  delete(id: number): Observable<Bank>{
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<Bank>(url);
  }

}
