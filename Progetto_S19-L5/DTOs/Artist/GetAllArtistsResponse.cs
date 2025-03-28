using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class GetAllArtistsResponse
    {
        [Required]
        public required string Message { get; set; }

        public List<ArtistDto>? Artists { get; set; }
    }
}
