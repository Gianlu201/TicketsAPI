using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_S19_L5.Data;
using Progetto_S19_L5.DTOs.Event;
using Progetto_S19_L5.Models;
using Progetto_S19_L5.Services;

namespace Progetto_S19_L5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(CreateEventRequestDto createEvent)
        {
            try
            {
                var newEvent = new Event()
                {
                    Title = createEvent.Title,
                    Place = createEvent.Place,
                    Date = createEvent.Date,
                    ArtistId = createEvent.ArtistId,
                };

                var result = await _eventService.CreateEventAsync(newEvent);

                return result
                    ? Ok(new CreateEventResponse() { Message = "Event created successfully!" })
                    : BadRequest(new CreateEventResponse() { Message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
