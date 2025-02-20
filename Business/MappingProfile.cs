using AutoMapper;
using Business.DTOs;
using Entities;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioRequestDTO, Usuario>();
            CreateMap<ActualizarUsuarioRequestDTO, Usuario>();

            CreateMap<Tienda, TiendaDTO>();
            CreateMap<TiendaRequestDTO, Tienda>();

            CreateMap<Articulo, ArticuloDTO>();
            CreateMap<ArticuloRequestDTO, Articulo>();
            CreateMap<ActualizarArticuloRequestDTO, Articulo>();

            CreateMap<ArticuloTienda, ArticuloEnTiendaDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Articulo.Id))
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Articulo.Codigo))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Articulo.Descripcion))
            .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Articulo.Precio))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Articulo.Stock))
            .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.Articulo.ImagenId.HasValue ? new ResourceResponse
            {
                Id = src.Articulo.ImagenId.Value,

            } : null));


            CreateMap<Tienda, TiendaArticuloDTO>()
           .ForMember(dest => dest.Tienda, opt => opt.MapFrom(src => new TiendaDTO
           {
               Id = src.Id,
               Sucursal = src.Sucursal,
               Direccion = src.Direccion
           }))
           .ForMember(dest => dest.Articulos, opt => opt.MapFrom(src => src.ArticuloTiendas.Select(at => new ArticuloEnTiendaDTO
           {
               Id = at.Articulo.Id,
               Codigo = at.Articulo.Codigo,
               Descripcion = at.Articulo.Descripcion,
               Precio = at.Articulo.Precio,
               Stock = at.Articulo.Stock,
               Fecha = at.Fecha,
               Imagen = at.Articulo.ImagenId.HasValue ? new ResourceResponse { Id = at.Articulo.ImagenId.Value } : null
           })));

            CreateMap<UsuarioArticulo, ArticuloEnCarritoDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Articulo.Id))
           .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Articulo.Codigo))
           .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Articulo.Descripcion))
           .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Articulo.Precio))
           .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.Articulo.ImagenId.HasValue ? new ResourceResponse { Id = src.Articulo.ImagenId.Value } : null))
           .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));

            CreateMap<Resource, ResourceResponse>();

            CreateMap<Menu, MenuResponse>();
        }
    }
}
