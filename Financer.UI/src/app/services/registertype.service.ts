import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { endpoints } from "../shared/endpoints/endpoints";
import { ApiService } from "../helper/api.service";
import { RegisterType, RegisterTypeCreate } from "../models/registertype";

@Injectable({
  providedIn: 'root'
})
export class RegisterTypeService {
  private endpoint = endpoints.registerType;

  constructor(private apiService: ApiService) {}

  getAll(): Observable<RegisterType[]> {
    return this.apiService.get<RegisterType[]>(this.endpoint);
  }

  getById(id: number): Observable<RegisterType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.get<RegisterType>(url);
  }

  create(registerType: RegisterTypeCreate): Observable<RegisterTypeCreate> {
    return this.apiService.post<RegisterTypeCreate>(this.endpoint, registerType);
  }

  update(registerType: RegisterType, id: number): Observable<RegisterType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.put<RegisterType>(url, registerType);
  }

  delete(id: number): Observable<RegisterType> {
    const url = `${this.endpoint}/${id}`;
    return this.apiService.delete<RegisterType>(url);
  }

  getTableColumns(){
    return ['name'];
  }

  getColumnNames(){
      return ['Register Type Name'];
  }
}
