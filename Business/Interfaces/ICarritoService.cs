using Business.DTOs;

namespace Business.Interfaces
{
    public interface ICarritoService
    {
        Task<bool> AgregarAlCarrito(CarritoDTO carritoDTO);
        Task<bool> EliminarDelCarrito(CarritoDTO carritoDTO);
        Task<IEnumerable<ArticuloEnCarritoDTO>> ObtenerCarrito(int userId);
    }
}
