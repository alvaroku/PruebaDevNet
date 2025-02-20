import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { TiendaDTO } from '../../models/models';
import { TiendaService } from '../../services/tienda.service';
import { firstValueFrom } from 'rxjs';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-tiendas',
  imports: [LoaderComponent,CommonModule,RouterLink],
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

  async eliminar(id:number){
    try {
      this.isLoading = true
        await firstValueFrom(this.tiendaService.eliminarTienda(id))
        this.ngOnInit()
        alert("Tienda eliminada")
    } catch (error) {

    }finally{
      this.isLoading = false
    }
  }
}
