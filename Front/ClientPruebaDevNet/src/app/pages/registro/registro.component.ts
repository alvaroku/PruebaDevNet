import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { LoginResponse, UsuarioRequestDTO } from '../../models/models';
import { LoaderComponent } from "../../components/loader/loader.component";
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-registro',
  imports: [LoaderComponent,CommonModule,ReactiveFormsModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {
  isLoading: boolean = false
  registerForm: FormGroup;
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

    this.registerForm = this.fb.group({
      nombre: ['', Validators.required],
      apellidos: [''],
      correo: ['', [Validators.required, Validators.email]],
      claveAcceso: ['', [Validators.required, Validators.minLength(5)]],
      direccion: ['']
    });
  }

  async onSubmit() {
    if (!this.registerForm.valid) return

    try {
      this.isLoading = true
      let payload: UsuarioRequestDTO = this.registerForm.value
      let response: LoginResponse = await firstValueFrom(this.authService.registro(payload))
      response.menus.push({ name: "Cerrar sesión", ruta: "logout" })
      this.authService.setCurrentUser(response)
      this.router.navigate(['/home']);

    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
}
