import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginRequest, LoginResponse, UsuarioRequestDTO } from '../models/models';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = environment.apiUrl

  private keyUserLocaStorage = 'currentUser'
  private currentUserSubject = new BehaviorSubject<LoginResponse | null>(null);
  currentUser$ = this.currentUserSubject.asObservable();

  constructor(private http: HttpClient)
  {
    const storedUser = localStorage.getItem(this.keyUserLocaStorage);
    const userData = storedUser ? JSON.parse(storedUser) : null;

    this.setCurrentUser(userData)
  }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}auth`, credentials);
  }

  registro(credentials: UsuarioRequestDTO): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}usuario`, credentials);
  }
  setCurrentUser(user: LoginResponse): void {
    this.currentUserSubject.next(user);
    localStorage.setItem(this.keyUserLocaStorage, JSON.stringify(user));
  }

  clearCurrentUser(): void {
    this.currentUserSubject.next(null);
    localStorage.removeItem(this.keyUserLocaStorage);
  }

}
