namespace Entities
{
    public class UsuarioArticulo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad {  get; set; }
        public DateTime Fecha { get; set; }
    }
}
