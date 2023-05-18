using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackisUppgift.Areas.Identity.Data;
using SnackisUppgift.Data;
using SnackisUppgift.Models;

namespace SnackisUppgift.Pages
{
    public class DmIndexModel : PageModel
    {
        private readonly SnackisUppgiftContext _context;
        private readonly UserManager<SnackisUppgiftUser> _userManager;

        public DmIndexModel(SnackisUppgiftContext context, UserManager<SnackisUppgiftUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<DirectMessage> DirectMessages { get;set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            DirectMessages = await _context.DirectMessages
                .Where(dm => dm.ReceiverId == userId || dm.SenderId == userId)
                .ToListAsync();
        }
    }
}
