using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            IEnumerable<UsuarioDTO> clientes = await _clienteService.ObtenerTodos();
            return Ok(clientes);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCliente([FromBody] UsuarioRequestDTO clienteDto)
        {
            LoginResponse nuevo = await _clienteService.Agregar(clienteDto);
            return CreatedAtAction(nameof(GetCliente), new { nuevo.User.Id }, nuevo);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, [FromBody] ActualizarUsuarioRequestDTO clienteDto)
        {
            await _clienteService.Actualizar(id, clienteDto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            await _clienteService.Eliminar(id);
            return NoContent();
        }
    }

}
