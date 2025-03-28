using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_S19_L5.DTOs.Artist;
using Progetto_S19_L5.Models;
using Progetto_S19_L5.Services;

namespace Progetto_S19_L5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistService _artistService;

        public ArtistController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistRequestDto newArtist)
        {
            try
            {
                var artist = new Artist()
                {
                    FirstName = newArtist.FirstName,
                    LastName = newArtist.LastName,
                    Genre = newArtist.Genre,
                    Biography = newArtist.Biography,
                };

                var result = await _artistService.CreateArtistAsync(artist);

                return result
                    ? Ok(new CreateArtistResponse() { Message = "Artist created successfully!" })
                    : BadRequest(new CreateArtistResponse() { Message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
