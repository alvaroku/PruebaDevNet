﻿namespace Business.DTOs
{
    public class ArticuloEnCarritoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad {  get; set; }
        public ResourceResponse Imagen { get; set; }
    }
}
