using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackisUppgift.Areas.Identity.Data;
using SnackisUppgift.Models;
using System.Security.Claims;

namespace SnackisUppgift.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.SnackisUppgiftContext _context;
        private readonly UserManager<SnackisUppgiftUser> _userManager;

        public IndexModel(Data.SnackisUppgiftContext context, UserManager<SnackisUppgiftUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Subject> Subjects { get; set; }

		public Models.Subject Subject { get; set; }
		public List<Models.Post> Posts { get; set; }

        [BindProperty]
        public Models.Post Post { get; set; }
        [BindProperty]
        public bool IsAnonymous { get; set; }
        public bool ShowForm { get; set; }
        public IFormFile UploadedImage { get; set; }
        public SnackisUppgiftUser MyUser { get; set; }



		public async Task<IActionResult> OnGetAsync(int subjectId = 0, int deleteid = 0, bool showForm = false)
		{
			ShowForm = showForm;
			Subjects = await DAL.SubjectManagerAPI.GetAllSubjects();

			if (subjectId != 0 || subjectId != null)
			{
				Subject = await DAL.SubjectManagerAPI.GetSubject(subjectId);
			}

			// Get the logged in user
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (!string.IsNullOrEmpty(userId))
			{
				MyUser = await _userManager.FindByIdAsync(userId);
			}

			if (deleteid != 0)
			{
				Models.Post blog = await _context.Post.FindAsync(deleteid);

				if (blog != null)
				{
					if (System.IO.File.Exists("./wwwroot/img/" + blog.Image))
					{
						System.IO.File.Delete("./wwwroot/img/" + blog.Image);
					}
					_context.Post.Remove(blog);
					await _context.SaveChangesAsync();
					return RedirectToPage("./Index");
				}
			}

			// Sort posts in descending order based on the date
			if (subjectId != 0)
			{
				Posts = await _context.Post
					.Where(p => p.SubjectId == subjectId)
					.OrderByDescending(p => p.Date)
					.ToListAsync();
			}
			else
			{
				Posts = await _context.Post
					.OrderByDescending(p => p.Date)
					.ToListAsync();
			}

			return Page();
		}



		[HttpPost]
		public async Task<IActionResult> OnPostAsync()
        {
			if (!ModelState.IsValid)
			{
				// Reload subjects and return page to display validation errors.
				Subjects = await _context.Subject.ToListAsync();
				return Page();
			}
			string filename = string.Empty;
            if (UploadedImage != null)
            {
                Random rnd = new();
                filename = rnd.Next(0, 100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + filename;
                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(filestream);
                }
            }

            Post.Date = DateTime.Now;
            Post.Image = filename;

            if (IsAnonymous)
            {
                Post.UserName = null;
            }
            else
            {
                Post.UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            _context.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public IActionResult OnPostToggleForm(bool showForm)
        {
            ShowForm = !showForm;
            return RedirectToPage(new { ShowForm });
        }
		

	}
}