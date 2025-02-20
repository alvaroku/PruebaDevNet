import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ArticuloDTO, ArticuloEnCarritoDTO } from '../models/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {

  private carritoUrl = `${environment.apiUrl}carrito`;
  constructor(private http: HttpClient) { }

  obtenerCarrito(userId:number): Observable<ArticuloEnCarritoDTO[]> {
    return this.http.get<ArticuloEnCarritoDTO[]>(`${this.carritoUrl}/obtener/${userId}`);
  }

  agregarAlCarrito(articuloId:number,userId:number): Observable<ArticuloDTO> {
    return this.http.post<ArticuloDTO>(`${this.carritoUrl}/agregar`, {articuloId,userId});
  }

  eliminarDelCarrito(articuloId: number,userId:number): Observable<boolean> {
    return this.http.post<boolean>(`${this.carritoUrl}/eliminar`,{articuloId,userId});
  }

}
