namespace Progetto_S19_L5.DTOs.Event
{
    public class EventSimpleDto
    {
        public int Eventid { get; set; }

        public required string Title { get; set; }

        public DateTime Date { get; set; }

        public required string Place { get; set; }
    }
}
