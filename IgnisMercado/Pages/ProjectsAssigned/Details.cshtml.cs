using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis.Pages.ProjectsAssigned
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public ProjectAssigned ProjectAssigned { get; set; }
        public IList<ProjectAssigned> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projects = await _context.ProjectAssigned
                .Include(e => e.Technician)
                .Include(d => d.Client).ToListAsync();
            
            Projects = Projects.Where(m => m.ID == id).ToList();;

            ProjectAssigned = Projects[0];

            if (ProjectAssigned == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
