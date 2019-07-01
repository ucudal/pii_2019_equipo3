using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Areas.Identity.Data;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.ProjectsFinished
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public ProjectFinished ProjectFinished { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectFinished = await _context.ProjectFinished.FirstOrDefaultAsync(m => m.ID == id);

            if (ProjectFinished == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
