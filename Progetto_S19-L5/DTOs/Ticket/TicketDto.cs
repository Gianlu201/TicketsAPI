using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Progetto_S19_L5.DTOs.Account;
using Progetto_S19_L5.DTOs.Event;
using Progetto_S19_L5.Models.Auth;

namespace Progetto_S19_L5.DTOs.Ticket
{
    public class TicketDto
    {
        [Required]
        public int Ticketid { get; set; }

        [Required]
        public DateTime DateBought { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public required string UserId { get; set; }

        // navigazione
        [ForeignKey(nameof(EventId))]
        public EventSimpleDto Event { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUserSimpleDto ApplicationUser { get; set; }
    }
}
