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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<ProjectAssigned> ProjectAssigned { get;set; }

        public async Task OnGetAsync()
        {
            ProjectAssigned = await _context.ProjectAssigned
                .Include(d => d.Technician).ToListAsync();
        }
    }
}
