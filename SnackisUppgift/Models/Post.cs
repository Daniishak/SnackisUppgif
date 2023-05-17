namespace SnackisUppgift.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int? Likes { get; set; }
        public int? Comments { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Subject? Subject { get; set; }
        public int? SubjectId { get; set; }
        public DateTime Date { get; set; }
        public string? UserName { get; set; }
    }
}
