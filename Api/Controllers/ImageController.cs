using Business;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IArticuloService _articuloService;
        public ImageController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Imagen(int id)
        {
            ResourceResponseArticle imagen = await _articuloService.GetImagen(id);
            if (imagen.Stream == null) return NotFound();
            return File(imagen.Stream, imagen.ContentType);
        }
    }
}
