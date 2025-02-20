import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { LoginResponse, UsuarioDTO } from '../../models/models';
import { UsuarioService } from '../../services/usuario.service';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-clientes',
  imports: [LoaderComponent, CommonModule,RouterLink],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class ClientesComponent implements OnInit {
  isLoading: boolean = false
  usuarios: UsuarioDTO[] = []
  currentUser:LoginResponse|null = null
  constructor(
    private usuarioService: UsuarioService,
    private authService:AuthService
  ) { }

  async ngOnInit() {
    this.currentUser = await firstValueFrom(this.authService.currentUser$)
    try {
      this.isLoading = true
      this.usuarios = await firstValueFrom(this.usuarioService.getUsuarios())
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
async  eliminar(id:number){
    try {
      this.isLoading = true
      await firstValueFrom(this.usuarioService.eliminarUsuarioPorId(id))
      this.ngOnInit()
      alert("Usuario eliminado correctamente")
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
}
