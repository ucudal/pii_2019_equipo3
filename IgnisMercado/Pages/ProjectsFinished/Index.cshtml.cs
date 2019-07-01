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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<ProjectFinished> ProjectFinished { get;set; }

        public async Task OnGetAsync()
        {
            ProjectFinished = await _context.ProjectFinished.ToListAsync();
        }
    }
}
