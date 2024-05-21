import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) {}

  private makeRequest<T>(method: string, endpoint: string, body?: any): Observable<T> {
    const completeEndpoint = `${this.baseURL}/${endpoint}`;
    return this.http.request<T>(method, completeEndpoint, { body })
      .pipe(
        catchError(this.handleError)
      );
  }

  get<T>(endpoint: string): Observable<T> {
    return this.makeRequest<T>('GET', endpoint);
  }

  post<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest<T>('POST', endpoint, body);
  }

  delete<T>(endpoint: string): Observable<T> {
    return this.makeRequest<T>('DELETE', endpoint);
  }

  put<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest<T>('PUT', endpoint, body);
  }

  patch<T>(endpoint: string, body: any): Observable<T> {
    return this.makeRequest<T>('PATCH', endpoint, body);
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.status === 0) {
      errorMessage = 'Could not connect to the server. Please check if the server is running and the network is available.';
    } else if (error.error instanceof ErrorEvent) {
      // Client-side or network error occurred.
      errorMessage = `A client-side or network error occurred: ${error.error.message}`;
    } else {
      // Backend returned an unsuccessful response code.
      errorMessage = `Backend returned code ${error.status}, body was: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
