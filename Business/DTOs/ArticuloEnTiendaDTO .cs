namespace Business.DTOs
{
    public class ArticuloEnTiendaDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha { get; set; }
        public ResourceResponse Imagen {  get; set; }
    }
}
