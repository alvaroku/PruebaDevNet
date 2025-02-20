using Business.DTOs;

namespace Business
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObtenerTodos();
        Task<ClienteDTO?> ObtenerPorId(int id);
        Task<LoginResponse> Agregar(ClienteRequestDTO cliente);
        Task Actualizar(int id, ActualizarClienteRequestDTO cliente);
        Task Eliminar(int id);
    }
}
