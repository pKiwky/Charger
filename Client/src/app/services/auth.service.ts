import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILoginResult } from '../interfaces/login-result.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  login(username: string, password: string) {
    return this.httpClient.post<ILoginResult>(
      'https://localhost:7214/api/Authentication/login',
      {
        username: username,
        password: password,
      }
    );
  }
}
