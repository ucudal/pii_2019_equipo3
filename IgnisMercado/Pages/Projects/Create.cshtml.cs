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

namespace RazorPagesIgnis.Pages.Projects
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
        public Project Project { get; set; }
        public Client Client { get; set; }
        public IList<Client> SelectedClient { get; set; }
        public string ClientId;
        public string ClientUserName;
        public async Task<IActionResult> OnPostAsync(string ClientId, string ClientUserName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ClientId == null && ClientUserName == null)
            {
                return NotFound();
            }
            else if(ClientUserName != null)
            {
                var clients = from t in _context.Client
                 select t;
                clients = clients.Where(s => s.UserName.Equals(ClientUserName));
                SelectedClient = await clients.ToListAsync();
                Client = SelectedClient[0];
            }
            else
            {
                Client = await _context.Client.FindAsync(ClientId);
            }
            
            Project.Client = Client;
            _context.Project.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}