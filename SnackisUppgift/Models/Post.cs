using System.ComponentModel.DataAnnotations;

namespace SnackisUppgift.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string? PostedBy { get; set; }
		public int? Likes { get; set; }
		public int? Comments { get; set; }
		public string? Image { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }

		public virtual Subject? Subject { get; set; }

		[Required(ErrorMessage = "Subject is required.")]
		public int SubjectId { get; set; }  // Make this non-nullable

		public DateTime? Date { get; set; }
		public string? UserName { get; set; }
	}
}
