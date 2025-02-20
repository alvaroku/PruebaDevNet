using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.UnitOfWork;
using Entities;

namespace Business.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper,IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(await _unitOfWork.Clientes.GetAll());
        }

        public async Task<UsuarioDTO?> ObtenerPorId(int id)
        {
            return _mapper.Map<UsuarioDTO>(await _unitOfWork.Clientes.GetById(id));
        }

        public async Task<LoginResponse> Registrar(UsuarioRequestDTO cliente)
        {
            Usuario nuevo = _mapper.Map<Usuario>(cliente);
            nuevo.HashedPassword = BCrypt.Net.BCrypt.HashPassword(cliente.ClaveAcceso);

            Rol? rol = await _unitOfWork.Roles.GetFirstOrDefault(x=>x.Name == "Cliente", $"{nameof(Rol.RoleMenus)}.{nameof(RoleMenu.Menu)}");
            nuevo.Rol = rol;

            await _unitOfWork.Clientes.Add(nuevo);
            await _unitOfWork.SaveChangesAsync();

            LoginResponse response = new LoginResponse
            {
                User = _mapper.Map<UsuarioDTO>(nuevo),
                Menus = rol.RoleMenus.Select(x => _mapper.Map<MenuResponse>(x.Menu)),
                Token = await _authService.GenerateToken(nuevo.Correo)
            };
            return response;
        }

        public async Task<UsuarioDTO> Agregar(UsuarioRequestDTO cliente)
        {
            Usuario nuevo = _mapper.Map<Usuario>(cliente);
            nuevo.HashedPassword = BCrypt.Net.BCrypt.HashPassword(cliente.ClaveAcceso);

            Rol? rol = await _unitOfWork.Roles.GetFirstOrDefault(x => x.Name == "Cliente", $"{nameof(Rol.RoleMenus)}.{nameof(RoleMenu.Menu)}");
            nuevo.Rol = rol;

            await _unitOfWork.Clientes.Add(nuevo);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UsuarioDTO>(nuevo);
        }

        public async Task Actualizar(int id, ActualizarUsuarioRequestDTO cliente)
        {
            Usuario? actualizar = await _unitOfWork.Clientes.GetById(id);
            if (actualizar != null) 
            {
                _mapper.Map(cliente, actualizar);
                _unitOfWork.Clientes.Update(actualizar);
                await _unitOfWork.SaveChangesAsync();
            }    
        }

        public async Task Eliminar(int id)
        {
            Usuario? cliente = await _unitOfWork.Clientes.GetById(id);
            if (cliente != null)
            {
                _unitOfWork.Clientes.Delete(cliente);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }

}
