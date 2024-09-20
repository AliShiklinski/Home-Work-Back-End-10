using MovieApp.Core.Entities;

public class ShowTime : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime => StartTime.AddMinutes(Movie.Duration);
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int TheaterId { get; set; }
    public Theater Theater { get; set; }
    public List<SeatReservation> SeatReservations { get; set; }
}