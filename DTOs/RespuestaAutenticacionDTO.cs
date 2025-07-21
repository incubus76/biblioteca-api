namespace BibliotecaAPI.DTOs
{
    public class RespuestaAutenticacionDTO
    {
        public required string Token { get; set; } = string.Empty;
        public DateTime Expiracion { get; set; }
    }
}
