﻿using Business;
using Business.DTOs;
using Business.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            IEnumerable<TiendaDTO> tiendas = await _tiendaService.ObtenerTodos();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTienda(int id)
        {
            var tienda = await _tiendaService.ObtenerPorId(id);
            if (tienda == null) return NotFound();
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarTienda([FromBody] TiendaRequestDTO tiendaDto)
        {
            TiendaDTO nuevo = await _tiendaService.Agregar(tiendaDto);
            return CreatedAtAction(nameof(GetTienda), new { nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTienda(int id, [FromBody] TiendaRequestDTO tiendaDto)
        {
            await _tiendaService.Actualizar(id, tiendaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTienda(int id)
        {
            await _tiendaService.Eliminar(id);
            return NoContent();
        }

        [HttpGet("{tiendaId}/obtenerArticulos")]
        public async Task<IActionResult> ObtenerArticulos(int tiendaId)
        {
            TiendaArticuloDTO articulo = await _tiendaService.ObtenerArticulos(tiendaId);
            if (articulo == null) return NotFound();
            return Ok(articulo);
        }

        [HttpPost("agregarArticuloATienda")]
        public async Task<IActionResult> AgregarArticuloATienda(AgregarArticuloATiendaDTO agregarArticulo)
        {
            bool articulo = await _tiendaService.AgregarArticuloATienda(agregarArticulo);
            return Ok(articulo);
        }

        [HttpPost("quitarArticuloATienda")]
        public async Task<IActionResult> QuitarArticuloATienda(QuitarArticuloATiendaDTO quitarArticulo)
        {
            bool articulo = await _tiendaService.QuitarArticuloATienda(quitarArticulo);
            return Ok(articulo);
        }
    }
}
