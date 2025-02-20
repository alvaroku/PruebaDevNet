import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { ArticuloEnTiendaDTO, LoginResponse, TiendaArticuloDTO } from '../../models/models';
import { TiendaService } from '../../services/tienda.service';
import { ArticuloService } from '../../services/articulo.service';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CarritoService } from '../../services/carrito.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-view-articulos',
  imports: [LoaderComponent, CommonModule],
  templateUrl: './view-articulos.component.html',
  styleUrl: './view-articulos.component.css'
})
export class ViewArticulosComponent {
  isLoading: boolean = false

  tiendaArticulos: TiendaArticuloDTO[] = [];

  constructor(
    private articuloService: ArticuloService,
    private carritoService: CarritoService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.cargarTiendaArticulos();
  }

  async cargarTiendaArticulos() {
    try {
      this.isLoading = true
      let data: TiendaArticuloDTO[] = await firstValueFrom(this.articuloService.obtenerArticulos())
      this.tiendaArticulos = data;
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
  getImagenUrl(imagenId: number): string {
    return `${environment.apiUrl}image/${imagenId}`;
  }
  async agregarAlCarrito(articulo: ArticuloEnTiendaDTO) {
    try {
      this.isLoading = true
      let user: LoginResponse | null = await firstValueFrom(this.authService.currentUser$)

      await firstValueFrom(this.carritoService.agregarAlCarrito(articulo.id, user?.user.id ?? 0));
      alert("Artículo añadido al carrito")
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
}
