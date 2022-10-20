import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private jwtHelper: JwtHelperService) {}

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');

    if (token && this.jwtHelper.isTokenExpired(token) == false) {
      return true;
    }

    return false;
  }

  public isAdmin(): boolean {
    var token = localStorage.getItem('token');
    const decodedToken = this.jwtHelper?.decodeToken(token!) || {};
    const role = decodedToken.role;
    return role === 'Admin';
  }
}
