using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Event
{
    public class CreateEventResponse
    {
        [Required]
        public required string Message { get; set; }
    }
}
