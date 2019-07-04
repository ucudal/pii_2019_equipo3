using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis.Pages.ProjectsAssigned
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public CreateModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProjectAssigned ProjectAssigned { get; set; }
        public string ClientUserName;
        public string TechnicianUserName;
        public Client Client { get; set; }
        public Technician Technician { get; set; }
        public IList<Client> SelectedClient { get; set; }
        public IList<Technician> SelectedTechnician { get; set; }

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

            _context.ProjectAssigned.Add(ProjectAssigned);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}