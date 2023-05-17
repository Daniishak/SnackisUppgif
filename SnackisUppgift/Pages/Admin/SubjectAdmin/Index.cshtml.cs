﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly SnackisUppgift.Data.SnackisUppgiftContext _context;

        public IndexModel(SnackisUppgift.Data.SnackisUppgiftContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subject != null)
            {
                Subject = await _context.Subject.ToListAsync();
            }
        }
    }
}
