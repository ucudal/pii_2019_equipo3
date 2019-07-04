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

namespace RazorPagesIgnis.Pages.ProjectsAssigned
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectAssigned ProjectAssigned { get; set; }
        public IList<ProjectAssigned> Projects { get; set; }
        public string ClientUserName;
        public string TechnicianUserName;
        public Client Client { get; set; }
        public Technician Technician { get; set; }
        public IList<Client> SelectedClient { get; set; }
        public IList<Technician> SelectedTechnician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projects = await _context.ProjectAssigned
                .Include(d => d.Technician)
                .Include(e => e.Client).ToListAsync();
            
            Projects = Projects.Where(m => m.ID == id).ToList();;

            ProjectAssigned = Projects[0];
            
            if (ProjectAssigned == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string ClientUserName, string TechnicianUserName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (TechnicianUserName == null && ClientUserName == null)
            {
                return NotFound();
            }
            else
            {
                var clients = from t in _context.Client
                 select t;
                clients = clients.Where(s => s.UserName.Equals(ClientUserName));
                SelectedClient = await clients.ToListAsync();
                Client = SelectedClient[0];

                var technicians = from t in _context.Technician
                 select t;
                technicians = technicians.Where(s => s.UserName.Equals(TechnicianUserName));
                SelectedTechnician = await technicians.ToListAsync();
                Technician = SelectedTechnician[0];

                ProjectAssigned.Client = Client;
                ProjectAssigned.Technician = Technician;
            }

            _context.Attach(ProjectAssigned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAssignedExists(ProjectAssigned.ID))
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

        private bool ProjectAssignedExists(int id)
        {
            return _context.ProjectAssigned.Any(e => e.ID == id);
        }
    }
}
