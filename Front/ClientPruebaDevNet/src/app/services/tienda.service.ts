import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TiendaDTO } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {

  private apiUrl = environment.apiUrl

  constructor(private http: HttpClient) { }

  getTiendas(): Observable<TiendaDTO[]> {
    return this.http.get<TiendaDTO[]>(`${this.apiUrl}tienda`);
  }
}
