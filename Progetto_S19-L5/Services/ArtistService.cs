using Microsoft.EntityFrameworkCore;
using Progetto_S19_L5.Data;
using Progetto_S19_L5.Models;

namespace Progetto_S19_L5.Services
{
    public class ArtistService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(ApplicationDbContext context, ILogger<ArtistService> logger)
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

        public async Task<bool> CreateArtistAsync(Artist artist)
        {
            try
            {
                _context.Artists.Add(artist);

                return await TrySaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Artist?> GetArtistByIdAsync(string artistId)
        {
            try
            {
                var artist = await _context
                    .Artists.Include(a => a.Events)
                    .FirstOrDefaultAsync(a => a.ArtistId.ToString() == artistId);

                return artist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
