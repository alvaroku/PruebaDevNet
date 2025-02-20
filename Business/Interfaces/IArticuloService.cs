using Business.DTOs;

namespace Business
{
    public interface IArticuloService
    {
        Task<IEnumerable<ArticuloDTO>> ObtenerTodos();
        Task<ArticuloDTO?> ObtenerPorId(int id);
        Task<ArticuloDTO> Agregar(ArticuloRequestDTO articulo, ResourceRequest? imagen);
        Task Actualizar(int id, ActualizarArticuloRequestDTO articulo, ResourceRequest? imagen);
        Task Eliminar(int id);
        Task<ResourceResponseArticle> GetImagen(int id);
    }
}
