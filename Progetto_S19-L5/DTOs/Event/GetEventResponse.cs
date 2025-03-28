using System.ComponentModel.DataAnnotations;

namespace Progetto_S19_L5.DTOs.Event
{
    public class GetEventResponse
    {
        [Required]
        public required string Message { get; set; }

        public EventDto? Event { get; set; }
    }
}
