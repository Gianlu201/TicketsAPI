using System.ComponentModel.DataAnnotations;
using Progetto_S19_L5.DTOs.Event;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class ArtistDto
    {
        [Required]
        public int ArtistId { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Genre { get; set; }

        public string? Biography { get; set; }

        // navigazione
        public ICollection<EventSimpleDto>? Events { get; set; }
    }
}
