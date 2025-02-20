using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ArticuloTienda> ArticuloTiendas { get; set; }
        public DbSet<UsuarioArticulo> UsuarioArticulos { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Name = "Administrador" },
                new Rol { Id = 2, Name = "Cliente" }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Clientes", Ruta = "/clientes" },
                new Menu { Id = 2, Name = "Tiendas", Ruta = "/tiendas" },
                new Menu { Id = 3, Name = "Artículos", Ruta = "/articulos" },
                new Menu { Id = 4, Name = "Ver Artículos", Ruta = "/view-articulos" },
                new Menu { Id = 5, Name = "Carrito", Ruta = "/carrito" }
            );

            modelBuilder.Entity<RoleMenu>().HasData(
                // El Administrador tiene acceso a Clientes, Tiendas y Artículos
                new RoleMenu { Id = 1, RolId = 1, MenuId = 1 }, // Clientes
                new RoleMenu { Id = 2, RolId = 1, MenuId = 2 }, // Tiendas
                new RoleMenu { Id = 3, RolId = 1, MenuId = 3 }, // Artículos

                // El Cliente puede ver Artículos y acceder al Carrito
                new RoleMenu { Id = 4, RolId = 2, MenuId = 4 }, // Ver Artículos
                new RoleMenu { Id = 5, RolId = 2, MenuId = 5 }  // Carrito
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Alvaro",
                    Apellidos = "Kú",
                    Correo = "alvaro.ku.dev@gmail.com",
                    Direccion = "Dirección de ejemplo",
                    HashedPassword = "$2a$11$enh.jL6h61wI53GMt.adBOSlZiAopheQRU2ZR4BdlBX8.zYAaz5r.",//12345
                    RolId = 1 // Rol Administrador,
                });
        }
    }
}
