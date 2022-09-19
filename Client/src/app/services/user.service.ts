import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private _jwtHelper: JwtHelperService) {}

  get isAdmin(): boolean {
    var token = localStorage.getItem('token');
    const decodedToken = this._jwtHelper?.decodeToken(token!) || {};
    const role = decodedToken.role;
    return role === 'Admin';
  }
}
