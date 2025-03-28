using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_S19_L5.Models
{
    public class Event
    {
        [Key]
        public int Eventid { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public required string Place { get; set; }

        public int ArtistId { get; set; }

        // navigazione
        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
