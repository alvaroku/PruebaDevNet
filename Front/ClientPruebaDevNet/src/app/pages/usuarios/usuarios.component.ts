import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { UsuarioDTO } from '../../models/models';
import { UsuarioService } from '../../services/usuario.service';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-clientes',
  imports: [LoaderComponent, CommonModule],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class ClientesComponent implements OnInit {
  isLoading: boolean = false
  usuarios: UsuarioDTO[] = []

  constructor(
    private usuarioService: UsuarioService,
  ) { }

  async ngOnInit() {
    try {
      this.isLoading = true
      this.usuarios = await firstValueFrom(this.usuarioService.getUsuarios())
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
}
