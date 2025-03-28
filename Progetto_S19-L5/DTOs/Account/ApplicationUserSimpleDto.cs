using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Account
{
    public class ApplicationUserSimpleDto
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}
