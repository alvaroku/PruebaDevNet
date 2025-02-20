import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ArticuloDTO, TiendaArticuloDTO } from '../models/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticuloService {

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) { }

  getArticulos(): Observable<ArticuloDTO[]> {
    return this.http.get<ArticuloDTO[]>(`${this.apiUrl}articulo`);
  }

  obtenerArticulos(): Observable<TiendaArticuloDTO[]> {
    return this.http.get<TiendaArticuloDTO[]>(`${this.apiUrl}articulo/obtenerArticulos`);
  }

  obtenerArticuloPorId(id: number): Observable<ArticuloDTO> {
    return this.http.get<ArticuloDTO>(`${this.apiUrl}articulo/${id}`);
  }

  agregarArticulo(articulo: FormData): Observable<ArticuloDTO> {
    return this.http.post<ArticuloDTO>(`${this.apiUrl}articulo`, articulo);
  }

  editarArticulo(id:number,articulo: FormData): Observable<ArticuloDTO> {
    return this.http.put<ArticuloDTO>(`${this.apiUrl}articulo/${id}`, articulo);
  }
}
