import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ArticuloDTO } from '../models/models';
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
}
