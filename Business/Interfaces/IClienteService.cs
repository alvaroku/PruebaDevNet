using Business.DTOs;

namespace Business
{
    public interface IClienteService
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerTodos();
        Task<UsuarioDTO?> ObtenerPorId(int id);
        Task<LoginResponse> Agregar(UsuarioRequestDTO cliente);
        Task Actualizar(int id, ActualizarUsuarioRequestDTO cliente);
        Task Eliminar(int id);
    }
}
