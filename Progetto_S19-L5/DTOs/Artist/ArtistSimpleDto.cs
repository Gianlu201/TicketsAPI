using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Artist
{
    public class ArtistSimpleDto
    {
        public int ArtistId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Genre { get; set; }

        public string? Biography { get; set; }
    }
}
