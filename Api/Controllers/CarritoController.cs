using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarAlCarrito([FromBody] CarritoDTO carritoDTO)
        {
            return Ok(await _carritoService.AgregarAlCarrito(carritoDTO));
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> EliminarDelCarrito([FromBody] CarritoDTO carritoDTO)
        {
            return Ok(await _carritoService.EliminarDelCarrito(carritoDTO));
        }

        [HttpGet("obtener/{userId}")]
        public async Task<IActionResult> ObtenerCarrito(int userId)
        {
            return Ok( await _carritoService.ObtenerCarrito(userId));
        }
    }
}
