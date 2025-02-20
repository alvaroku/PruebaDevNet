using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.UnitOfWork;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Implementations
{
    public class JwtService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public JwtService(IConfiguration config, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> GenerateToken(string username, string role = "")
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            Cliente? cliente = await _unitOfWork.Clientes.GetFirstOrDefault(x=>x.Correo.ToLower().Equals(request.Email.ToLower()));
            if (cliente is null) return null;
            bool esValida = BCrypt.Net.BCrypt.Verify(request.Password, cliente.HashedPassword);
            if (!esValida) return null;

            LoginResponse response = new LoginResponse
            {
                Cliente = _mapper.Map<ClienteDTO>(cliente),
                Token = await GenerateToken(request.Email)
            };
            return response;
        }
    }
}
