using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Ticket
{
    public class DeleteTicketResponse
    {
        [Required]
        public required string Message { get; set; }
    }
}
