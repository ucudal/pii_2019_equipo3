using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesIgnis.Models
{
    public static class SeedTechnicians
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesIgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesIgnisContext>>()))
            {
                // Look for any movies.
                if (context.Technician.Any())
                {
                    return;   // DB has been seeded
                }

                context.Technician.AddRange(
                    new Technician
                    {
                        Name = "Juan Martinez",
                        Age = 20,
                        Mail = "example1@example.com",
                        Specialty = "Fotógrafo",
                        Level = "Avanzado",
                    },

                    new Technician
                    {
                        Name = "Jose Rodriguez",
                        Age = 22,
                        Mail = "example2@example.com",
                        Specialty = "Fotógrafo",
                        Level = "Intermedio",
                    },

                    new Technician
                    {
                        Name = "Manuel Garcia",
                        Age = 25,
                        Mail = "example3@example.com",
                        Specialty = "Camarógrafo",
                        Level = "Intermedio",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}