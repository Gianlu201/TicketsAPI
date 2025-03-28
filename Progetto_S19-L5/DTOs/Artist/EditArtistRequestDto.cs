using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class EditArtistRequestDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Genre { get; set; }

        public string? Biography { get; set; }
    }
}
