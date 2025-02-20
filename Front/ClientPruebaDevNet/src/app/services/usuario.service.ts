import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActualizarUsuarioRequestDTO, UsuarioDTO, UsuarioRequestDTO } from '../models/models';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<UsuarioDTO[]> {
    return this.http.get<UsuarioDTO[]>(`${this.apiUrl}usuario`);
  }

  getUsuarioPorId(id: number): Observable<UsuarioDTO> {
    return this.http.get<UsuarioDTO>(`${this.apiUrl}usuario/${id}`);
  }

  crearUsuario(payload: UsuarioRequestDTO): Observable<UsuarioDTO> {
    return this.http.post<UsuarioDTO>(`${this.apiUrl}usuario`, payload);
  }

  actualizarUsuario(id: number, payload: ActualizarUsuarioRequestDTO): Observable<UsuarioDTO> {
    return this.http.put<UsuarioDTO>(`${this.apiUrl}usuario/${id}`, payload);
  }

  eliminarUsuarioPorId(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}usuario/${id}`);
  }
}
