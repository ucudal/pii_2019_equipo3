using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RazorPagesIgnis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            this.RolesList = new List<SelectListItem>();
            for (int i = 0; i < IdentityData.NonAdminRoleNames.Length; i++)
            {
                this.RolesList.Add(new SelectListItem { Value = i.ToString(), Text = IdentityData.NonAdminRoleNames[i] });
            }
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        [BindProperty]
        public int Role { get; set; }

        [BindProperty]
        public List<SelectListItem> RolesList { get; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _userManager.FindByIdAsync(id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }

            this.Role = Array.BinarySearch(IdentityData.NonAdminRoleNames, ApplicationUser.Role);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(this.ApplicationUser.Id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var rolesForUser = await _userManager.GetRolesAsync(user);
            foreach (var roleToRemove in rolesForUser)
            {
                if (roleToRemove.Equals(IdentityData.AdminRoleName))
                {
                    throw new InvalidOperationException($"Cannot edit '{IdentityData.AdminRoleName}'.");
                }
                _userManager.RemoveFromRoleAsync(user, roleToRemove).Wait();
            }

            var roleToAdd = await _roleManager.FindByNameAsync(IdentityData.NonAdminRoleNames[this.Role]);
            _userManager.AddToRoleAsync(user, roleToAdd.Name).Wait();

            // Es necesario tener acceso a RoleManager para poder buscar el rol de este usuario; se asigna aquí para poder
            // buscar por rol después cuando no hay acceso a RoleManager.
            user.AssignRole(_userManager, roleToAdd.Name);

            await _userManager.UpdateAsync(user);

            return RedirectToPage("./Index");
        }

        private bool ApplicationUserExists(string id)
        {
            var user = _userManager.FindByIdAsync(id);
            return user != null;
        }
    }
}
