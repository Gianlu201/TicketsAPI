using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_S19_L5.DTOs.Account;
using Progetto_S19_L5.DTOs.Event;
using Progetto_S19_L5.DTOs.Ticket;
using Progetto_S19_L5.Models;
using Progetto_S19_L5.Services;

namespace Progetto_S19_L5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequestDto createTicket)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                var userId = user.Value;

                var newTicket = new Ticket()
                {
                    DateBought = createTicket.DateBought,
                    EventId = createTicket.EventId,
                    UserId = userId,
                };

                var result = await _ticketService.CreateTicketAsync(newTicket);

                return result
                    ? Ok(new CreateTicketResponse() { Message = "Ticket created successfully!" })
                    : BadRequest(new CreateTicketResponse() { Message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var result = await _ticketService.GetAllTicketsAsync();

                if (result == null)
                {
                    return BadRequest(
                        new GetAllTicketsResponse()
                        {
                            Message = "Something went wrong!",
                            Tickets = null,
                        }
                    );
                }

                List<TicketDto> ticketsList = result
                    .Select(t => new TicketDto()
                    {
                        Ticketid = t.Ticketid,
                        EventId = t.EventId,
                        DateBought = t.DateBought,
                        UserId = t.UserId,
                        Event = new EventSimpleDto()
                        {
                            Eventid = t.Event.Eventid,
                            Title = t.Event.Title,
                            Place = t.Event.Place,
                            Date = t.Event.Date,
                        },
                        ApplicationUser = new ApplicationUserSimpleDto()
                        {
                            Id = t.ApplicationUser.Id,
                            FirstName = t.ApplicationUser.FirstName,
                            LastName = t.ApplicationUser.LastName,
                            Email = t.ApplicationUser.Email,
                        },
                    })
                    .ToList();

                return Ok(
                    new GetAllTicketsResponse()
                    {
                        Message = "Tickets found!",
                        Tickets = ticketsList,
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{ticketId:int}")]
        [Authorize]
        public async Task<IActionResult> GetTicket(int ticketId)
        {
            try
            {
                var result = await _ticketService.GetTicketByIdAsync(ticketId);

                if (result == null)
                {
                    return BadRequest(
                        new GetTicketResponse() { Message = "Something went wrong!", Ticket = null }
                    );
                }

                var ticketFound = new TicketDto()
                {
                    Ticketid = result.Ticketid,
                    DateBought = result.DateBought,
                    EventId = result.EventId,
                    UserId = result.UserId,
                    Event = new EventSimpleDto()
                    {
                        Eventid = result.Event.Eventid,
                        Title = result.Event.Title,
                        Date = result.Event.Date,
                        Place = result.Event.Place,
                    },
                    ApplicationUser = new ApplicationUserSimpleDto()
                    {
                        Id = result.ApplicationUser.Id,
                        FirstName = result.ApplicationUser.FirstName,
                        LastName = result.ApplicationUser.LastName,
                        Email = result.ApplicationUser.Email,
                    },
                };

                return Ok(
                    new GetTicketResponse() { Message = "Ticket found!", Ticket = ticketFound }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{ticketId:int}")]
        [Authorize]
        public async Task<IActionResult> EditTicket(
            int ticketId,
            [FromBody] EditTicketRequestDto editTicket
        )
        {
            try
            {
                var result = await _ticketService.EditTicketByIdAsync(ticketId, editTicket);

                return result
                    ? Ok(new EditTicketResponse() { Message = "Ticket modified successfully!" })
                    : BadRequest(new EditTicketResponse() { Message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ticketId:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var result = await _ticketService.DeleteTicketByIdAsync(ticketId);

            return result
                ? Ok(new DeleteTicketResponse() { Message = "Ticket deleted successfully" })
                : BadRequest(new DeleteTicketResponse() { Message = "Something went wrong!" });
        }
    }
}
