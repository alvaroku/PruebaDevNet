using Data.UnitOfWork.RepositoryPattern;
using Entities;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Usuario> Clientes { get; }
        IRepository<Tienda> Tiendas { get; }
        IRepository<Articulo> Articulos { get; }
        IRepository<Resource> Resources { get; }
        Task SaveChangesAsync();
    }
}
