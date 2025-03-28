using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class CreateArtistResponse
    {
        [Required]
        public required string Message { get; set; }
    }
}
