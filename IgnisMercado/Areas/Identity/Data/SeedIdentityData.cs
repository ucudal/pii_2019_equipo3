using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesIgnis.Areas.Identity.Data
{
    /// <summary>
    /// Inicializa en la base de datos de identidad los usuarios y roles necesarios para el funcionamiento de la aplicaci�n
    /// la primera vez que se ejecuta.
    /// </summary>
    public static class SeedIdentityData
    {
        /// <summary>
        /// Crea los usuarios y roles necesarios para el funcionamiento de la aplicaci�n si ya no existente.
        /// </summary>
        /// <param name="serviceProvider">El <see cref="IServiceProvider"/> al que se han injectado previamente un
        /// <see cref="UserManager<T>"/> y un <see cref="RoleManager<T>"/>.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // Crea el primer y �nico administrador si no existe. Primero crea un usuario y luego se asigna el rol de adminstrador.
            if (userManager.FindByNameAsync(IdentityData.AdminUserName).Result == null)
            {
                ApplicationUser admin = new ApplicationUser();
                try
                {
                    admin.Name = IdentityData.AdminName;
                }
                catch (InvalidOperationException e)
                {
                    
                    throw e;
                }  
                admin.UserName = IdentityData.AdminUserName;
                admin.Email = IdentityData.AdminMail;
                admin.DOB = IdentityData.AdminDOB;

                ApplicationUser tech = new ApplicationUser();
                try
                {
                    tech.Name = IdentityData.TechName;
                }
                catch (InvalidOperationException e)
                {
                    
                    throw e;
                }
                tech.UserName = IdentityData.TechUserName;
                tech.Email = IdentityData.TechMail;
                tech.DOB = IdentityData.TechDOB;

                ApplicationUser client = new ApplicationUser();
                try
                {
                    client.Name = IdentityData.ClientName;
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }
                client.UserName = IdentityData.ClientUserName;
                client.Email = IdentityData.ClientMail;
                client.DOB = IdentityData.ClientDOB;

                // Es necesario tener acceso a RoleManager para poder buscar el rol de este usuario; se asigna aquí para poder
                // buscar por rol después cuando no hay acceso a RoleManager.
                admin.AssignRole(userManager, IdentityData.AdminRoleName);
                tech.AssignRole(userManager, IdentityData.TechRoleName);
                client.AssignRole(userManager, IdentityData.ClientRoleName);

                IdentityResult result1 = userManager.CreateAsync(admin, IdentityData.AdminPassword).Result;
                IdentityResult result2 = userManager.CreateAsync(tech, IdentityData.AdminPassword).Result;
                IdentityResult result3 = userManager.CreateAsync(client, IdentityData.AdminPassword).Result;
                if (result1.Succeeded && result2.Succeeded && result3.Succeeded)
                {
                    IdentityResult addRoleResult1 = userManager.AddToRoleAsync(admin, IdentityData.AdminRoleName).Result;
                    IdentityResult addRoleResult2 = userManager.AddToRoleAsync(tech, IdentityData.TechRoleName).Result;
                    IdentityResult addRoleResult3 = userManager.AddToRoleAsync(client, IdentityData.ClientRoleName).Result;
                    if (!addRoleResult1.Succeeded || !addRoleResult2.Succeeded || !addRoleResult3.Succeeded)
                    {
                        throw new InvalidOperationException(
                            "Unexpected error ocurred adding role to user.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Unexpected error ocurred creating user.");
                }
            }
        }

        private static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            // Crea un rol si no existe.
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole role = new IdentityRole(roleName);
                IdentityResult createRoleResult = roleManager.CreateAsync(role).Result;
                if (!createRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating role '{role}'.");
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Crea el rol de administrador si no existe
            CreateRole(roleManager, IdentityData.AdminRoleName);

            foreach (var roleName in IdentityData.NonAdminRoleNames)
            {
                CreateRole(roleManager, roleName);
            }
        }
    }
}