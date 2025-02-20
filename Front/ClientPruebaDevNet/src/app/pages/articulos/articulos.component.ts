import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { ArticuloDTO } from '../../models/models';
import { ArticuloService } from '../../services/articulo.service';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../../environments/environment';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-articulos',
  imports: [LoaderComponent, CommonModule,RouterLink],
  templateUrl: './articulos.component.html',
  styleUrl: './articulos.component.css'
})
export class ArticulosComponent implements OnInit {
  isLoading: boolean = false
  articulos: ArticuloDTO[] = [];
  constructor(private articuloService: ArticuloService) { }

  async ngOnInit() {
    try {
      this.isLoading = true
      this.articulos = await firstValueFrom(this.articuloService.getArticulos())
    } catch (error) {

    }finally{
      this.isLoading = false
    }
  }

  getImagenUrl(imagenId: number): string {
    return `${environment.apiUrl}image/${imagenId}`;
  }
}
