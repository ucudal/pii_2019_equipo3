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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectAssigned ProjectAssigned { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectAssigned = await _context.ProjectAssigned.FirstOrDefaultAsync(m => m.ID == id);

            if (ProjectAssigned == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectAssigned = await _context.ProjectAssigned.FindAsync(id);

            if (ProjectAssigned != null)
            {
                _context.ProjectAssigned.Remove(ProjectAssigned);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
