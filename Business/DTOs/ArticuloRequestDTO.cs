﻿namespace Business.DTOs
{
    public class ArticuloRequestDTO
    {
        public string IdTiendas {  get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
