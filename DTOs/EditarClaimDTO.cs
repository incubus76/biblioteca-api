using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs
{
    public class EditarClaimDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
