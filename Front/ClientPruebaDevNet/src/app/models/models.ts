export interface UsuarioDTO {
  id: number;
  nombre: string;
  apellidos: string;
  correo: string;
  direccion: string;
}

export interface ActualizarUsuarioRequestDTO {
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

export interface TiendaDTO {
  id: number;
  sucursal: string;
  direccion: string;
}

export interface TiendaRequestDTO {
  sucursal: string;
  direccion: string;
}

export interface ResourceResponse {
  id: number;
}

export interface ArticuloDTO {
  id: number;
  codigo: string;
  descripcion: string;
  precio: number;
  stock: number;
  imagen: ResourceResponse;
}

export interface ArticuloEnCarritoDTO {
  id: number;
  codigo: string;
  descripcion: string;
  precio: number;
  cantidad: number;
  imagen: ResourceResponse;
}

export interface ArticuloRequestDTO {
  tiendaId: number;
  codigo: string;
  descripcion: string;
  precio: number;
  stock: number;
  imagen?: File;
}

export interface ActualizarArticuloRequestDTO {
  codigo: string;
  descripcion: string;
  precio: number;
  stock: number;
  imagen?: File;
}

export interface ArticuloEnTiendaDTO {
  id: number;
  codigo: string;
  descripcion: string;
  precio: number;
  stock: number;
  fecha:Date
  imagen: ResourceResponse;
}

export interface TiendaArticuloDTO{
  tienda:TiendaDTO
  articulos:ArticuloEnTiendaDTO[]
}

export interface AgregarArticuloATiendaDTO{
  tiendaId:number
  articuloId:number
}

export interface QuitarArticuloATiendaDTO{
  tiendaId:number
  articuloId:number
}
