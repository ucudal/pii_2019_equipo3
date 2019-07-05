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
        public IList<ProjectFinished> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projects = await _context.ProjectFinished
                .Include(d => d.Technician)
                .Include(e => e.Client)
                .Include(f => f.Feedback).ToListAsync();
            
            Projects = Projects.Where(m => m.ID == id).ToList();;

            ProjectFinished = Projects[0];

            if (ProjectFinished == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
