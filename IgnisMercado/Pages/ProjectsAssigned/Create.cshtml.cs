using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.ProjectsAssigned
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;

        public CreateModel(RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProjectAssigned ProjectAssigned { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProjectAssigned.Add(ProjectAssigned);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}