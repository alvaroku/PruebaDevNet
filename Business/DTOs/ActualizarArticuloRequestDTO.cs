namespace Business.DTOs
{
    public class ActualizarArticuloRequestDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
