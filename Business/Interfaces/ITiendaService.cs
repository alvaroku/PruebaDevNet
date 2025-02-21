﻿using Business.DTOs;

namespace Business
{
    public interface ITiendaService
    {
        Task<IEnumerable<TiendaDTO>> ObtenerTodos();
        Task<TiendaDTO?> ObtenerPorId(int id);
        Task<TiendaDTO> Agregar(TiendaRequestDTO tienda);
        Task Actualizar(int id, TiendaRequestDTO tienda);
        Task Eliminar(int id);
        Task<TiendaArticuloDTO> ObtenerArticulos(int tiendaId);
        Task<bool> AgregarArticuloATienda(AgregarArticuloATiendaDTO agregarArticulo);
        Task<bool> QuitarArticuloATienda(QuitarArticuloATiendaDTO quitarArticulo);
    }
}
