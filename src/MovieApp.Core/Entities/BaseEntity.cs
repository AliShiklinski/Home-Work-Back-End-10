namespace MovieApp.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModidieDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
