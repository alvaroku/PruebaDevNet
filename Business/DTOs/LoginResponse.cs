namespace Business.DTOs
{
    public class LoginResponse
    {
        public UsuarioDTO User { get; set; }
        public IEnumerable<MenuResponse> Menus { get; set; }
        public string Token {  get; set; }
    }
}
