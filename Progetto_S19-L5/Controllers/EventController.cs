using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_S19_L5.Data;
using Progetto_S19_L5.DTOs.Artist;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateEventRequestDto createEvent)
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

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _eventService.GetAllEventsAsync();

            if (result == null)
            {
                return Ok(
                    new GetAllEventsResponse() { Message = "No event found!", Events = null }
                );
            }

            List<EventDto> eventsList = result
                .Select(e => new EventDto()
                {
                    Eventid = e.Eventid,
                    Title = e.Title,
                    Place = e.Place,
                    Date = e.Date,
                    ArtistId = e.ArtistId,
                    Artist = new ArtistSimpleDto()
                    {
                        ArtistId = e.Artist.ArtistId,
                        FirstName = e.Artist.FirstName,
                        LastName = e.Artist.LastName,
                        Genre = e.Artist.Genre,
                        Biography = e.Artist.Biography,
                    },
                })
                .ToList();

            var count = eventsList.Count;

            var message = count == 1 ? $"{count} event found!" : $"{count} events found!";

            return Ok(new GetAllEventsResponse() { Message = message, Events = eventsList });
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEvent(string eventId)
        {
            try
            {
                var result = await _eventService.GetEventByIdAsync(eventId);

                if (result == null)
                {
                    return BadRequest(
                        new GetEventResponse() { Message = "Something went wrong!", Event = null }
                    );
                }

                var eventFound = new EventDto()
                {
                    Eventid = result.Eventid,
                    Title = result.Title,
                    Place = result.Place,
                    Date = result.Date,
                    ArtistId = result.Artist.ArtistId,
                    Artist = new ArtistSimpleDto()
                    {
                        ArtistId = result.Artist.ArtistId,
                        FirstName = result.Artist.FirstName,
                        LastName = result.Artist.LastName,
                        Genre = result.Artist.Genre,
                        Biography = result.Artist.Biography,
                    },
                };

                return Ok(new GetEventResponse() { Message = "Event found!", Event = eventFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{eventId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEvent(
            string eventId,
            [FromBody] EditEventRequestDto editEvent
        )
        {
            try
            {
                var editResult = await _eventService.EditEventAsync(eventId, editEvent);

                return editResult
                    ? Ok(new EditEventResponse() { Message = "Event modified successfully!" })
                    : BadRequest(new EditEventResponse() { Message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{eventId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int eventId)
        {
            var result = await _eventService.DeleteEventByIdAsync(eventId);

            return result
                ? Ok(new DeleteEventResponse() { Message = "Event deleted successfully!" })
                : BadRequest(new DeleteEventResponse() { Message = "Something went wrong!" });
        }
    }
}
