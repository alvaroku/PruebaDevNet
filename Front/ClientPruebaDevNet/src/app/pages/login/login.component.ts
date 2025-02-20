import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { LoginRequest, LoginResponse } from '../../models/models';
import { LoaderComponent } from "../../components/loader/loader.component";
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [LoaderComponent,CommonModule,ReactiveFormsModule,RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  isLoading: boolean = false
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {

    authService.currentUser$.subscribe((x: LoginResponse | null) => {
      if (x) {
        router.navigate(["/home"])
      }
    });

    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }
  get email() {
    return this.loginForm.get('email')!;
  }

  get password() {
    return this.loginForm.get('password')!;
  }
  async onSubmit() {
    if (this.loginForm.invalid) return;

    try {
      this.isLoading = true
      let payload: LoginRequest = this.loginForm.value
      let response: LoginResponse = await firstValueFrom(this.authService.login(payload))
      response.menus.push({ name: "Cerrar sesión", ruta: "logout" })
      this.authService.setCurrentUser(response);
      this.router.navigate(['/home']);
    }
    finally {
      this.isLoading = false
    }
  }
}
