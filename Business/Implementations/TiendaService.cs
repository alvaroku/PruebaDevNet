using AutoMapper;
using Business.DTOs;
using Data.UnitOfWork;
using Entities;

namespace Business.Implementations
{
    public class TiendaService: ITiendaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TiendaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TiendaDTO>> ObtenerTodos()
        {
            return _mapper.Map<IEnumerable<TiendaDTO>>(await _unitOfWork.Tiendas.GetAll());
        }

        public async Task<TiendaDTO?> ObtenerPorId(int id)
        {
            return _mapper.Map<TiendaDTO>(await _unitOfWork.Tiendas.GetById(id));
        }

        public async Task<TiendaDTO> Agregar(TiendaRequestDTO tienda)
        {
            Tienda nuevo = _mapper.Map<Tienda>(tienda);
            await _unitOfWork.Tiendas.Add(nuevo);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TiendaDTO>(nuevo);
        }

        public async Task Actualizar(int id, TiendaRequestDTO tienda)
        {
            Tienda? actualizar = await _unitOfWork.Tiendas.GetById(id);
            if (actualizar != null)
            {
                _mapper.Map(tienda, actualizar);
                _unitOfWork.Tiendas.Update(actualizar);
                await _unitOfWork.SaveChangesAsync();
            }   
        }

        public async Task Eliminar(int id)
        {
            Tienda? Tienda = await _unitOfWork.Tiendas.GetById(id);
            if (Tienda != null)
            {
                _unitOfWork.Tiendas.Delete(Tienda);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
