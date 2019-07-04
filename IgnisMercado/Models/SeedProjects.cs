using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesIgnis.Models
{
    public static class SeedProjects
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesIgnis.Areas.Identity.Data.IdentityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesIgnis.Areas.Identity.Data.IdentityContext>>()))
            {
                // Look for any movies.
                if (context.Project.Any())
                {
                    return;   // DB has been seeded
                }
                ProjectsSeeder(serviceProvider);
                
            }
        }
        public static void ProjectsSeeder(IServiceProvider serviceProvider)
            {
                using (var context = new RazorPagesIgnis.Areas.Identity.Data.IdentityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesIgnis.Areas.Identity.Data.IdentityContext>>())){

                if (context.Project.Any()){
                    return;   // DB has been seeded
                };

                var Projects = new Project[]{
                    new Project { Specialty = "Fotógrafo",
                        Level = "Avanzado",
                        Description = "Buscamos fotógrafo para sesión de publicidad.",
                        NHours = 3,},
                    new Project {Specialty = "Fotógrafo",
                        Level = "Intermedio",
                        Description = "Se necesita fotógrafo para congreso a llevarse a cabo en la institución.",
                        NHours = 1,},
                    new Project {  Specialty = "Sonidista",
                        Level = "Intermedio",
                        Description = "Se necesita camarógrafo para la grabación de videoclip promocional.",
                        NHours = 7,
                        },
                    };
                    foreach (Project p in Projects)
                    {
                        Client query = context.Client
                        .Where(s => s.UserName == "fic@ignis.com")
                        .FirstOrDefault<Client>();
                        p.Client=query;
                        context.Project.Add(p);
                    };
                    context.SaveChanges();
            }
        }
    }
}