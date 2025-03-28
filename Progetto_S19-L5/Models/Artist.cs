using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Genre { get; set; }

        public string? Biography { get; set; }

        // navigazione
        public ICollection<Event>? Events { get; set; }
    }
}
