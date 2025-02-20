namespace Business.DTOs
{
    public class LoginResponse
    {
        public ClienteDTO Cliente { get; set; }
        public string Token {  get; set; }
    }
}
