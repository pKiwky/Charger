import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPaginatedResult } from '../interfaces/paginated-result.interface';
import { IStation } from '../interfaces/station.interface';
import { Station } from '../models/station.model';

@Injectable({
  providedIn: 'root',
})
export class StationService {
  constructor(private httpClient: HttpClient) {}

  create(station: Station) {
    return this.httpClient.post(`https://localhost:7214/api/Station`, {
      city: station.city,
      street: station.street,
      latitude: station.latitude,
      longitude: station.longitude,
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
