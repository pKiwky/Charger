import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private toastrServie: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  onSubmit() {
    var username = this.loginForm.get('username')?.value;
    var password = this.loginForm.get('password')?.value;

    this.authService.login(username, password).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('username', response.username);

        this.toastrServie.success('Successfully logged.');
        this.router.navigate(['/']);
      },
      error: (error) => {
        if (error.status === 404) {
          this.toastrServie.error('Account does not exists.');
        }
      },
    });
  }
}
