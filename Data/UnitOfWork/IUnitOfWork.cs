using Data.UnitOfWork.RepositoryPattern;
using Entities;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Usuario> Clientes { get; }
        IRepository<Tienda> Tiendas { get; }
        IRepository<Articulo> Articulos { get; }
        IRepository<ArticuloTienda> ArticuloTiendas { get; }
        IRepository<Resource> Resources { get; }
        IRepository<Rol> Roles { get; }
        Task SaveChangesAsync();
    }
}
