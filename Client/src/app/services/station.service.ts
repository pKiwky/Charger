import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StationService {
  constructor(private httpClient: HttpClient) { }

  getAllStations() {
    return this.httpClient.get('https://jsonplaceholder.typicode.com/comments');
  }
}
