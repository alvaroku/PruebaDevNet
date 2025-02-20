export interface UsuarioDTO {
  id: number;
  nombre: string;
  apellidos: string;
  correo: string;
  direccion: string;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  user: UsuarioDTO;
  token: string;
  menus: MenuResponse[]
}

export interface UsuarioRequestDTO {
  nombre: string
  correo: string
  claveAcceso: string
  apellidos: string
  direccion: string
}

export interface MenuResponse {
  name: string
  ruta: string
}
