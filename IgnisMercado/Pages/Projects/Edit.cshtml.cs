using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }
        public Client Client { get; set; }
        public String ClientUserName;
        public IList<Client> SelectedClient { get; set; }
        public IList<Project> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             Projects = await _context.Project
                .Include(d => d.Client).ToListAsync();
            
            Projects = Projects.Where(m => m.ID == id).ToList();;

            Project = Projects[0];

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string ClientUserName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ClientUserName != null)
            {
                var clients = from t in _context.Client
                 select t;
                clients = clients.Where(s => s.UserName.Equals(ClientUserName));
                SelectedClient = await clients.ToListAsync();
                Client = SelectedClient[0];
                Project.Client = Client;
            }

            _context.Attach(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ID == id);
        }
    }
}
