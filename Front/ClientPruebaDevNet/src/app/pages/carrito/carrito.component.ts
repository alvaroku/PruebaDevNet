import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { ArticuloDTO, ArticuloEnCarritoDTO, LoginResponse } from '../../models/models';
import { CarritoService } from '../../services/carrito.service';
import { AuthService } from '../../services/auth.service';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-carrito',
  imports: [LoaderComponent,CommonModule],
  templateUrl: './carrito.component.html',
  styleUrl: './carrito.component.css'
})
export class CarritoComponent implements OnInit {
  isLoading: boolean = false
  carrito: ArticuloEnCarritoDTO[] = [];

  user: LoginResponse | null = null

  constructor(private carritoService: CarritoService, private authService: AuthService) { }

  async ngOnInit() {
    this.user = await firstValueFrom(this.authService.currentUser$)
    this.carrito = await firstValueFrom(this.carritoService.obtenerCarrito(this.user?.user.id ?? 0));
  }

  async quitarDelCarrito(articulo: ArticuloEnCarritoDTO) {
    try {
      this.isLoading = true
      let user: LoginResponse | null = await firstValueFrom(this.authService.currentUser$)

      await firstValueFrom(this.carritoService.eliminarDelCarrito(articulo.id, user?.user.id ?? 0));
      this.carrito = await firstValueFrom(this.carritoService.obtenerCarrito(this.user?.user.id ?? 0));
      alert("Artículo eliminado del carrito")
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }

  calcularTotal(): number {
    return this.carrito.reduce((total, articulo) => total + articulo.precio * articulo.cantidad, 0);
  }

  getImagenUrl(imagenId: number): string {
    return `${environment.apiUrl}image/${imagenId}`;
  }
}
