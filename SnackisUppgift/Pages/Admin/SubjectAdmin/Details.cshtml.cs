using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackisUppgift.Data;
using SnackisUppgift.Models;

namespace SnackisUppgift.Pages.Admin.SubjectAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly SnackisUppgift.Data.SnackisUppgiftContext _context;

        public DetailsModel(SnackisUppgift.Data.SnackisUppgiftContext context)
        {
            _context = context;
        }

      public Subject Subject { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            else 
            {
                Subject = subject;
            }
            return Page();
        }
    }
}
