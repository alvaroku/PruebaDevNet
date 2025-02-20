namespace Entities
{
    public class ArticuloTienda
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
