import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICar } from '../interfaces/car.interface';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  constructor(private httpClient: HttpClient) {}

  getAll(): Observable<ICar[]> {
    return this.httpClient.get<ICar[]>(`https://localhost:7214/api/car`);
  }
}
