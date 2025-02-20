using Data.UnitOfWork.RepositoryPattern;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Usuario> Clientes { get; }
        public IRepository<Tienda> Tiendas { get; }
        public IRepository<Articulo> Articulos { get; }
        public IRepository<Resource> Resources { get; }
        public UnitOfWork(AppDbContext context, IRepository<Usuario> cliente, IRepository<Tienda> tienda, IRepository<Articulo> articulo, IRepository<Resource> resource)
        {
            _context = context;
            Clientes = cliente;
            Tiendas = tienda;
            Articulos = articulo;
            Resources = resource;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
