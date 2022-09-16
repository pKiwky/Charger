import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginComponent } from '../auth/login/login.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  isLogged: boolean = false;

  constructor(
    private toastrServie: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void { }

  isLoggedIn() {
    this.isLogged = localStorage.getItem('token') !== null;
    return this.isLogged;
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('role');

    this.toastrServie.success("You are logged out.");
    this.router.navigate(['/']);
  }
}
