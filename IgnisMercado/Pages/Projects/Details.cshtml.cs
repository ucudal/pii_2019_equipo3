using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
