using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Ticket
{
    public class GetAllTicketsResponse
    {
        [Required]
        public required string Message { get; set; }

        public List<TicketDto>? Tickets { get; set; }
    }
}
