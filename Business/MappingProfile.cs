using AutoMapper;
using Business.DTOs;
using Entities;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteRequestDTO, Cliente>();
            CreateMap<ActualizarClienteRequestDTO, Cliente>();

            CreateMap<Tienda, TiendaDTO>();
            CreateMap<TiendaRequestDTO, Tienda>();

            CreateMap<Articulo, ArticuloDTO>();
            CreateMap<ArticuloRequestDTO, Articulo>();

            CreateMap<Resource, ResourceResponse>();
        }
    }
}
