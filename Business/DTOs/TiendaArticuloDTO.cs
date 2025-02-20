namespace Business.DTOs
{
    public class TiendaArticuloDTO
    {
        public TiendaDTO Tienda { get; set; }
        public IEnumerable<ArticuloEnTiendaDTO> Articulos { get; set; }
    }
}