using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Event
{
    public class CreateEventRequestDto
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public required string Place { get; set; }

        [Required]
        public int ArtistId { get; set; }
    }
}
