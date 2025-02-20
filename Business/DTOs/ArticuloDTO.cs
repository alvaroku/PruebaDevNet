namespace Business.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public ResourceResponse Imagen {  get; set; }
    }
}
