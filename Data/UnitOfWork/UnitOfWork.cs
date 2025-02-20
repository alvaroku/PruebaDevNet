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
        public IRepository<ArticuloTienda> ArticuloTiendas { get; }
        public IRepository<Resource> Resources { get; }
        public IRepository<Rol> Roles {  get; }
        public UnitOfWork(AppDbContext context, 
            IRepository<Usuario> cliente, IRepository<Tienda> tienda, 
            IRepository<Articulo> articulo, IRepository<ArticuloTienda> articuloTiendas, IRepository<Resource> resource,
            IRepository<Rol> rol)
        {
            _context = context;
            Clientes = cliente;
            Tiendas = tienda;
            ArticuloTiendas = articuloTiendas;
            Articulos = articulo;
            Resources = resource;
            Roles = rol;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
