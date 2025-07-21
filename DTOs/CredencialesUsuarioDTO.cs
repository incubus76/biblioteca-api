using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs
{
    public class CredencialesUsuarioDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool Recordarme { get; set; } = false;
    }
}
