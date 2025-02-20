namespace Entities
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int? ImagenId {  get; set; }
        public Resource? Imagen { get; set; }
        public int Stock { get; set; }
        public ICollection<ArticuloTienda> ArticuloTiendas { get; set; }
        public ICollection<UsuarioArticulo> UsuarioArticulos { get; set; }
    }

}
