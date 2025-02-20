import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { TiendaDTO } from '../../models/models';
import { TiendaService } from '../../services/tienda.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-tiendas',
  imports: [LoaderComponent,CommonModule],
  templateUrl: './tiendas.component.html',
  styleUrl: './tiendas.component.css'
})
export class TiendasComponent implements OnInit {
  isLoading:boolean = false
  tiendas: TiendaDTO[] = [];
  constructor(private tiendaService: TiendaService) {}
 async ngOnInit() {
      try {
        this.isLoading = true
        this.tiendas = await firstValueFrom(this.tiendaService.getTiendas())
      } catch (error) {

      }finally{
        this.isLoading = false
      }
  }
}
