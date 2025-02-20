﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250220033117_data-user")]
    partial class datauser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImagenId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImagenId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Entities.ArticuloTienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TiendaId");

                    b.ToTable("ArticuloTiendas");
                });

            modelBuilder.Entity("Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Clientes",
                            Ruta = "/clientes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tiendas",
                            Ruta = "/tiendas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Artículos",
                            Ruta = "/articulos"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ver Artículos",
                            Ruta = "/view-articulos"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Carrito",
                            Ruta = "/carrito"
                        });
                });

            modelBuilder.Entity("Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rols");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cliente"
                        });
                });

            modelBuilder.Entity("Entities.RoleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RolId");

                    b.ToTable("RoleMenus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuId = 1,
                            RolId = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuId = 2,
                            RolId = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuId = 3,
                            RolId = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuId = 4,
                            RolId = 2
                        },
                        new
                        {
                            Id = 5,
                            MenuId = 5,
                            RolId = 2
                        });
                });

            modelBuilder.Entity("Entities.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Kú",
                            Correo = "alvaro.ku.dev@gmail.com",
                            Direccion = "Dirección de ejemplo",
                            HashedPassword = "$2a$11$enh.jL6h61wI53GMt.adBOSlZiAopheQRU2ZR4BdlBX8.zYAaz5r.",
                            Nombre = "Alvaro",
                            RolId = 1
                        });
                });

            modelBuilder.Entity("Entities.UsuarioArticulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ClienteId");

                    b.ToTable("UsuarioArticulos");
                });

            modelBuilder.Entity("Entities.Articulo", b =>
                {
                    b.HasOne("Entities.Resource", "Imagen")
                        .WithMany()
                        .HasForeignKey("ImagenId");

                    b.Navigation("Imagen");
                });

            modelBuilder.Entity("Entities.ArticuloTienda", b =>
                {
                    b.HasOne("Entities.Articulo", "Articulo")
                        .WithMany("ArticuloTiendas")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Tienda", "Tienda")
                        .WithMany("ArticuloTiendas")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("Entities.RoleMenu", b =>
                {
                    b.HasOne("Entities.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Rol", "Rol")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Entities.Usuario", b =>
                {
                    b.HasOne("Entities.Rol", "Rol")
                        .WithMany("Users")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Entities.UsuarioArticulo", b =>
                {
                    b.HasOne("Entities.Articulo", "Articulo")
                        .WithMany("UsuarioArticulos")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Usuario", "Cliente")
                        .WithMany("UsuarioArticulos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Entities.Articulo", b =>
                {
                    b.Navigation("ArticuloTiendas");

                    b.Navigation("UsuarioArticulos");
                });

            modelBuilder.Entity("Entities.Menu", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("Entities.Rol", b =>
                {
                    b.Navigation("RoleMenus");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.Tienda", b =>
                {
                    b.Navigation("ArticuloTiendas");
                });

            modelBuilder.Entity("Entities.Usuario", b =>
                {
                    b.Navigation("UsuarioArticulos");
                });
#pragma warning restore 612, 618
        }
    }
}
