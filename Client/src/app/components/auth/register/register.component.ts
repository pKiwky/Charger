import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private toastrServie: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
    });
  }

  onSubmit() {
    var username = this.registerForm.get('username')?.value;
    var password = this.registerForm.get('password')?.value;
    var confirmPassword = this.registerForm.get('confirmPassword')?.value;
    var email = this.registerForm.get('email')?.value;

    this.authService.register(username, password, confirmPassword, email).subscribe({
      next: (response) => {
        this.toastrServie.success("Account was successfully created.");
        this.router.navigate(['/login']);
      },
      error: (error) => {
        this.toastrServie.error(error.error);
      },
    });
  }
}
