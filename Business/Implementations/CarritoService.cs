using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.UnitOfWork;
using Entities;

namespace Business.Implementations
{
    public class CarritoService : ICarritoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarritoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AgregarAlCarrito(CarritoDTO carritoDTO)
        {
            UsuarioArticulo? usuarioArticulo = await _unitOfWork.UsuarioArticulos.GetFirstOrDefault(x => x.ClienteId == carritoDTO.UserId && x.ArticuloId == carritoDTO.ArticuloId);

            if (usuarioArticulo is null)
            {
                await _unitOfWork.UsuarioArticulos
                    .Add(new UsuarioArticulo {Cantidad = 1, ArticuloId = carritoDTO.ArticuloId, ClienteId = carritoDTO.UserId });
            }
            else
            {
                usuarioArticulo.Cantidad++;
            }

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarDelCarrito(CarritoDTO carritoDTO)
        {
            UsuarioArticulo? usuarioArticulo = await _unitOfWork.UsuarioArticulos.GetFirstOrDefault(x => x.ClienteId == carritoDTO.UserId && x.ArticuloId == carritoDTO.ArticuloId);

            if (usuarioArticulo is null)
                throw new Exception("El artículo no existe en el carrito");

            _unitOfWork.UsuarioArticulos.Delete(usuarioArticulo);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ArticuloEnCarritoDTO>> ObtenerCarrito(int userId)
        {
            Usuario usuario = await _unitOfWork.Clientes.GetById(userId, $"{nameof(Usuario.UsuarioArticulos)}.{nameof(UsuarioArticulo.Articulo)}.{nameof(Articulo.Imagen)}");

            return _mapper.Map<IEnumerable<ArticuloEnCarritoDTO>>(usuario.UsuarioArticulos);
        }
    }
}
