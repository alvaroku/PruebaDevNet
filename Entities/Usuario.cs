namespace Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo {  get; set; }
        public string HashedPassword {  get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int RolId {  get; set; }
        public Rol Rol { get; set; }
        public ICollection<UsuarioArticulo> UsuarioArticulos { get; set; }
    }
}
