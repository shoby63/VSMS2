import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private apiUrl ='https://localhost:7278/api/Vehicles'; // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

    getVehicles(): Observable<any[]> {
      return this.http.get<any[]>(this.apiUrl).pipe(
        catchError(this.handleError)
      );
    }

    updateVehicle() {

    }

    createVehicle() {
      
    }
  
    private handleError(error: any) {
      console.error('An error occurred:', error);
      return throwError('Something went wrong; please try again later.');
    }
}
