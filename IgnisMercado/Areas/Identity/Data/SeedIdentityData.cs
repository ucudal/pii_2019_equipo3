using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesIgnis.Models;

/* 
Esta clase es la que crea las instancias de administradores, clientes y tecnicos ya 
que es la que tiene los datos necesario para ello por esto cumple, 
con el patrón Expert y a su vez cumple con el patrón Creator. 

Inicializa en la base de datos de identidad los usuarios y roles necesarios 
para el funcionamiento de la aplicacion la primera vez que se ejecuta.

Crea los usuarios y roles necesarios para el funcionamiento de la aplicacion si ya no existente.
*/

namespace RazorPagesIgnis.Areas.Identity.Data
{
    public static class SeedIdentityData
    {
        /// <param name="serviceProvider">El <see cref="IServiceProvider"/> al que se han injectado previamente un
        /// <see cref="UserManager<T>"/> y un <see cref="RoleManager<T>"/>.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedClients(userManager,serviceProvider);
            SeedTechnicians(userManager,serviceProvider);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // Crea el primer administrador si no existe. Primero crea un usuario y luego se asigna el rol de adminstrador.
            if (userManager.FindByNameAsync(IdentityData.AdminUserName).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                ApplicationUser admin = new ApplicationUser();
                try
                {
                    admin.Name = IdentityData.AdminName;
                }
                catch (InvalidOperationException e)
                {
                    
                    throw e;
                }  
                user.UserName = IdentityData.AdminUserName;
                user.Email = IdentityData.AdminMail;
                user.DOB = IdentityData.AdminDOB;
                // Es necesario tener acceso a RoleManager para poder buscar el rol de este usuario; se asigna aquí para poder
                // buscar por rol después cuando no hay acceso a RoleManager.
                user.AssignRole(userManager, IdentityData.AdminRoleName);

                IdentityResult result = userManager.CreateAsync(user, IdentityData.AdminPassword).Result;

                if (result.Succeeded)
                {
                    IdentityResult addRoleResult = userManager.AddToRoleAsync(user, IdentityData.AdminRoleName).Result;
                    if (!addRoleResult.Succeeded)
                    {
                        throw new InvalidOperationException(
                            $"Unexpected error ocurred adding role '{IdentityData.AdminRoleName}' to user '{IdentityData.AdminName}'.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating user '{IdentityData.AdminName}'.");
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
        private static void SeedClients(UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
        {   
            using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>())){

                if (context.Client.Any()){
                    Console.WriteLine("RETURN");
                    return;  
                };
            }

            for (int i = 0; i < Clients.ClientNames.Count(); i++)
            {
                Console.WriteLine("numero de clientes " + i.ToString());
                CreateClient(Clients.ClientNames[i],
                Clients.ClientDOBs[i],
                Clients.ClientMail[i],
                IdentityData.AdminPassword,
                userManager);
            }
        }
        private static void SeedTechnicians(UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
        {   
            using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>())){

                if (context.Technician.Any()){
                    return;  
                };
            }

            for (int i = 0; i <= Technicians.TechnicianNames.Count()-1; i++)
            {
                Console.WriteLine("numero de tecnicos " + i.ToString());
                CreateTechnician(
                Technicians.TechnicianNames[i],
                Technicians.TechnicianDOBs[i],
                Technicians.TechnicianMail[i],
                IdentityData.AdminPassword,
                Technicians.Specialities[i],
                Technicians.Levels[i],
                userManager);
            }
        }
        private static void CreateClient(
        string name,
        DateTime dob,
        string email,
        string password,
        UserManager<ApplicationUser> userManager)
        {
             var user = new Client {
                    Name = name,
                    UserName = email,
                    Email = email,
                    DOB = dob
                };
            user.AssignRole(userManager, IdentityData.NonAdminRoleNames[0]);

            IdentityResult result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                IdentityResult addRoleResult = userManager.AddToRoleAsync(user, IdentityData.NonAdminRoleNames[0]).Result;
                if (!addRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Unexpected error ocurred adding role '{IdentityData.NonAdminRoleNames[0]}' to user '{name}'.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected error ocurred creating user '{name}'.");
            }
        }
        private static void CreateTechnician(
        string name,
        DateTime dob,
        string email,
        string password,
        string rol,
        string level,
        UserManager<ApplicationUser> userManager)
        {
            
            var user = new Technician {
                    Name = name,
                    DOB = dob,
                    UserName = email,
                    Email = email
                };
            user.Specialty=rol;
            user.Level=level;
            user.AssignRole(userManager, IdentityData.NonAdminRoleNames[1]);

            IdentityResult result = userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                IdentityResult addRoleResult = userManager.AddToRoleAsync(user, IdentityData.NonAdminRoleNames[1]).Result;
                if (!addRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Unexpected error ocurred adding role '{IdentityData.NonAdminRoleNames[1]}' to user '{name}'.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected error ocurred creating user '{name}'.");
            }
        }
    }
}