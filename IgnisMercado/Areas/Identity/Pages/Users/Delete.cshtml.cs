using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;


namespace RazorPagesIgnis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] 
    // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FindAsync(id);

            if (ApplicationUser != null)
            {
                _context.Users.Remove(ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
