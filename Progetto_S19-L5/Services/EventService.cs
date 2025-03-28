using Progetto_S19_L5.Data;
using Progetto_S19_L5.Models;

namespace Progetto_S19_L5.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArtistService> _logger;

        public EventService(ApplicationDbContext context, ILogger<ArtistService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private async Task<bool> TrySaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> CreateEventAsync(Event newEvent)
        {
            try
            {
                var result = _context.Events.Add(newEvent);

                return await TrySaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
