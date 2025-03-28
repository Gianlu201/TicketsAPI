using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Ticket
{
    public class EditTicketRequestDto
    {
        [Required]
        public DateTime DateBought { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public required string UserId { get; set; }
    }
}
