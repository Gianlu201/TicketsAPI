using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Progetto_S19_L5.DTOs.Artist;
using Progetto_S19_L5.Models;

namespace Progetto_S19_L5.DTOs.Event
{
    public class EventDto
    {
        public int Eventid { get; set; }

        public required string Title { get; set; }

        public DateTime Date { get; set; }

        public required string Place { get; set; }

        public int ArtistId { get; set; }

        // navigazione
        [ForeignKey(nameof(ArtistId))]
        public ArtistSimpleDto Artist { get; set; }
    }
}
