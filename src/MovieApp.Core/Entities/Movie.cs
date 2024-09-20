namespace MovieApp.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public double Duration { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Genres { get; set; }
        public List<ShowTime> ShowTimes { get; set; }
    }
}
