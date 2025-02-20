using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }   

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ArticuloTienda> ArticuloTiendas { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    }
}
