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
            using (var context = new RazorPagesIgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesIgnisContext>>()))
            {
                // Look for any movies.
                if (context.Project.Any())
                {
                    return;   // DB has been seeded
                }

                context.Project.AddRange(
                    new Project
                    {
                        Specialty = "Fotógrafo",
                        Level = "Avanzado",
                        Description = "-",
                        NHours = 3,
                    },
                    new Project
                    {
                        Specialty = "Fotógrafo",
                        Level = "Intermedio",
                        Description = "-",
                        NHours = 1,
                    },
                    new Project
                    {
                        Specialty = "Camarógrafo",
                        Level = "Intermedio",
                        Description = "-",
                        NHours = 7,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}