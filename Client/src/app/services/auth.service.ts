import { HttpClient } from '@angular/common/http';
import { Injectable, SimpleChange } from '@angular/core';
import { ILoginResult } from '../interfaces/login-result.interface';
import { IRegisterResult } from '../interfaces/register-result.interface';

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

  register(username: string, password: string, confirmPassword: string, email: string) {
    return this.httpClient.post<IRegisterResult>(
      'https://localhost:7214/api/Authentication/register',
      {
        username: username,
        password: password,
        confirmPassword: confirmPassword,
        email: email
      }
    );
  }
}
