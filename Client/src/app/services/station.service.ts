import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPaginatedResult } from '../interfaces/paginated-result.interface';
import { IStation } from '../interfaces/station.interface';

@Injectable({
  providedIn: 'root',
})
export class StationService {
  constructor(private httpClient: HttpClient) {}

  create() {
    return this.httpClient.post(`https://localhost:7214/api/Station`, {
      city: 'string',
      street: 'string',
      latitude: 0,
      longitude: 0,
    });
  }

  getPaginated(pageNumber: number, pageSize: number) {
    return this.httpClient.get<IPaginatedResult>(
      `https://localhost:7214/api/station/GetPaginated/${pageNumber}/${pageSize}`
    );
  }

  delete(id: number) {
    return this.httpClient.delete<boolean>(
      `https://localhost:7214/api/station/${id}`
    );
  }
}
