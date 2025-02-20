import { Component } from '@angular/core';
import { LoaderComponent } from "../../../components/loader/loader.component";
import { AgregarArticuloATiendaDTO, ArticuloDTO, QuitarArticuloATiendaDTO, TiendaArticuloDTO } from '../../../models/models';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TiendaService } from '../../../services/tienda.service';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ArticuloService } from '../../../services/articulo.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-articulos-tienda',
  imports: [LoaderComponent,CommonModule,ReactiveFormsModule],
  templateUrl: './articulos-tienda.component.html',
  styleUrl: './articulos-tienda.component.css'
})
export class ArticulosTiendaComponent {
  isLoading: boolean = false
  tiendaArticulos: TiendaArticuloDTO | null = null;
  articulosDisponibles: ArticuloDTO[] = [];
  articuloForm!: FormGroup;
  tiendaId: number = 0;

  constructor(
    private route: ActivatedRoute,
    private tiendaService: TiendaService,
    private articuloService: ArticuloService,
    private fb: FormBuilder
  ) {
    this.articuloForm = this.fb.group({
      articuloId: ['']
    });
  }

  ngOnInit(): void {
    this.cargarArticulosDisponibles()
    this.route.params.subscribe(params => {
      this.tiendaId = +params['id'];
      this.cargarArticulosDeTienda();
    });
  }

  async cargarArticulosDeTienda() {
    try {
      this.isLoading = true
      this.tiendaArticulos = await firstValueFrom(this.tiendaService.getArticulosPorTienda(this.tiendaId))
    } catch (error) {

    } finally {
      this.isLoading = false
    }

  }

  async cargarArticulosDisponibles() {
    try {
      this.isLoading = true
      this.articulosDisponibles = await firstValueFrom(this.articuloService.getArticulos())
    } catch (error) {

    } finally {
      this.isLoading = false
    }

  }

  async agregarArticulo() {
    const articuloId = this.articuloForm.value.articuloId;
    if (!articuloId) return;

    try {
      this.isLoading = true
      let payload:AgregarArticuloATiendaDTO = {tiendaId:this.tiendaId, articuloId:articuloId}
      await firstValueFrom(this.tiendaService.agregarArticuloATienda(payload))
      await this.cargarArticulosDeTienda();
      alert("Se agregó el artículo a la tienda")
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }

  async quitarArticulo(articuloId: number) {
    try {
      this.isLoading = true
      let payload:QuitarArticuloATiendaDTO = {tiendaId:this.tiendaId, articuloId:articuloId}
      await firstValueFrom(this.tiendaService.quitarArticuloATienda(payload))
      this.cargarArticulosDeTienda();
      alert("Se eliminó el artículo de la tienda")
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }

    getImagenUrl(imagenId: number): string {
      return `${environment.apiUrl}image/${imagenId}`;
    }
}
