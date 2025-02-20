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

            CreateMap<Resource, ResourceResponse>();

            CreateMap<Menu, MenuResponse>();
        }
    }
}
