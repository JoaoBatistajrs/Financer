import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from '../shared/endpoints/endpoints';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) {}

  makeRequest(method: string, endpoint: string, body?: any): Observable<any> {
    const completeEndpoint = `${this.baseURL}/${endpoint}`;
    console.log(completeEndpoint);
    return this.http.request<any>(method, completeEndpoint, { body })
      .pipe(
        catchError(this.handleError)
      );
  }

  get<T>(endpoint: string): Observable<T> {
    return this.makeRequest('get', endpoint);
  }

  post<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest('post', endpoint, body);
  }

  delete<T>(endpoint: string): Observable<T> {
    return this.makeRequest('delete', endpoint);
  }

  put<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest('put', endpoint, body);
  }

  patch<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest('patch', endpoint, body);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('Could not connect to the server.');
    } else {
      console.error(
        `An error ocurred: ${error.status}, ${error.statusText}`
      );
    }
    return throwError(() => new Error(error.error));
  }
}
