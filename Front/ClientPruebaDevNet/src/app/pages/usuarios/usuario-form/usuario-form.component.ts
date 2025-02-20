import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../../components/loader/loader.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioService } from '../../../services/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ActualizarUsuarioRequestDTO, UsuarioDTO, UsuarioRequestDTO } from '../../../models/models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuario-form',
  imports: [LoaderComponent,CommonModule,ReactiveFormsModule],
  templateUrl: './usuario-form.component.html',
  styleUrl: './usuario-form.component.css'
})
export class UsuarioFormComponent implements OnInit {
  isLoading: boolean = false
  usuarioForm!: FormGroup;
  usuarioId!: number;
  esEdicion = false;
  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  ngOnInit() {
    this.usuarioForm = this.fb.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
      direccion: ['', Validators.required],
      claveAcceso: [''],
    });

    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.esEdicion = true;
        this.usuarioId = parseInt(id);
        this.cargarUsuario(this.usuarioId);
      }
    });
    if(!this.esEdicion){
      this.usuarioForm.get('claveAcceso')?.setValidators([Validators.required]);
      this.usuarioForm.get('claveAcceso')?.updateValueAndValidity();
    }
  }

  async cargarUsuario(id: number) {
    try {
      this.isLoading = true
      let usuario: UsuarioDTO = await firstValueFrom(this.usuarioService.getUsuarioPorId(id))
      this.usuarioForm.patchValue(usuario);
    } catch (error) {

    }finally{
      this.isLoading = false
    }
  }

 async onSubmit() {
    if (this.usuarioForm.invalid) return;

    try {
      this.isLoading = true
      if(this.esEdicion){
        let payload:ActualizarUsuarioRequestDTO =  this.usuarioForm.value
        await firstValueFrom(this.usuarioService.actualizarUsuario(this.usuarioId,payload))
      }else{
        let payload:UsuarioRequestDTO =  this.usuarioForm.value
        await firstValueFrom(this.usuarioService.crearUsuario(payload))
      }
      alert('Usuario guardado correctamente');
      this.router.navigate(['/clientes']);
    } catch (error) {

    }finally{
      this.isLoading = false
    }


  }
}
