using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticulos()
        {
            IEnumerable<ArticuloDTO> articulos = await _articuloService.ObtenerTodos();
            return Ok(articulos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulo(int id)
        {
            var articulo = await _articuloService.ObtenerPorId(id);
            if (articulo == null) return NotFound();
            return Ok(articulo);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarArticulo([FromForm] ArticuloRequestDTO articuloDto, IFormFile? imagen)
        {
            ResourceRequest? newResourceRequest = null;
            if (imagen != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                await imagen.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                newResourceRequest = new ResourceRequest
                {
                    Stream = memoryStream,
                    ContentType = imagen.ContentType,
                    Extension = Path.GetExtension(imagen.FileName),
                };
            }
            ArticuloDTO nuevo = await _articuloService.Agregar(articuloDto, newResourceRequest);
            return CreatedAtAction(nameof(GetArticulo), new { nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArticulo(int id, [FromForm] ActualizarArticuloRequestDTO articuloDto, IFormFile? imagen)
        {
            ResourceRequest? newResourceRequest = null;
            if (imagen != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                await imagen.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                newResourceRequest = new ResourceRequest
                {
                    Stream = memoryStream,
                    ContentType = imagen.ContentType,
                    Extension = Path.GetExtension(imagen.FileName)
                };
            }
            await _articuloService.Actualizar(id, articuloDto, newResourceRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarArticulo(int id)
        {
            await _articuloService.Eliminar(id);
            return NoContent();
        }
    }
}
