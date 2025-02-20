import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AgregarArticuloATiendaDTO, ArticuloDTO, QuitarArticuloATiendaDTO, TiendaArticuloDTO, TiendaDTO, TiendaRequestDTO } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) { }

  getTiendas(): Observable<TiendaDTO[]> {
    return this.http.get<TiendaDTO[]>(`${this.apiUrl}tienda`);
  }

  crearTienda(payload:TiendaRequestDTO): Observable<TiendaDTO> {
    return this.http.post<TiendaDTO>(`${this.apiUrl}tienda`,payload);
  }

  actualizarTienda(tiendaId:number,payload:TiendaRequestDTO): Observable<TiendaDTO> {
    return this.http.put<TiendaDTO>(`${this.apiUrl}tienda/${tiendaId}`,payload);
  }

  eliminarTienda(tiendaId:number): Observable<TiendaDTO> {
    return this.http.delete<TiendaDTO>(`${this.apiUrl}tienda/${tiendaId}`);
  }

  getTiendaIdPorId(tiendaId:number): Observable<TiendaDTO> {
    return this.http.get<TiendaDTO>(`${this.apiUrl}tienda/${tiendaId}`);
  }

  getArticulosPorTienda(tiendaId:number): Observable<TiendaArticuloDTO> {
    return this.http.get<TiendaArticuloDTO>(`${this.apiUrl}tienda/${tiendaId}/obtenerArticulos`);
  }

  agregarArticuloATienda(payload:AgregarArticuloATiendaDTO): Observable<ArticuloDTO> {
    return this.http.post<ArticuloDTO>(`${this.apiUrl}tienda/agregarArticuloATienda`,payload);
  }

  quitarArticuloATienda(payload:QuitarArticuloATiendaDTO): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}tienda/quitarArticuloATienda`,payload);
  }
}
