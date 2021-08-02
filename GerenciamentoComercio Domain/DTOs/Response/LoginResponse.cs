namespace GerenciamentoComercio_Domain.DTOs.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public UserResponse User { get; set; }
    }
}
