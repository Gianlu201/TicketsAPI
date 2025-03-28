using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class GetArtistResponse
    {
        [Required]
        public required string Message { get; set; }

        public ArtistDto? Artist { get; set; }
    }
}
