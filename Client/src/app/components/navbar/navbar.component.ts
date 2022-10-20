import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';
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
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void { }

  isLoggedIn() {
    return this.userService.isAuthenticated();
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('role');

    this.toastrServie.success("You are logged out.");
    this.router.navigate(['/']);
  }
}
