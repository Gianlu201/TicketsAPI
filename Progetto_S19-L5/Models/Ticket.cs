using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Progetto_S19_L5.Models.Auth;

namespace Progetto_S19_L5.Models
{
    public class Ticket
    {
        [Key]
        public int Ticketid { get; set; }

        [Required]
        public DateTime DateBought { get; set; }

        public int ArtistId { get; set; }

        public int EventId { get; set; }

        public string UserId { get; set; }

        // navigazione
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
