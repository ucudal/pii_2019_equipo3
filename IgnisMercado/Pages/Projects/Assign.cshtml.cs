using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.Projects
{
    public class AssignModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;

        public AssignModel(RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
        }

        public IList<Technician> Technician { get;set; }

        public Project Project { get; set; }

        public Technician TechnicianSelected { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Project = await _context.Project.FindAsync(id);

            var technicians = from t in _context.Technician
                 select t;
            if (Project != null)
            {
                technicians = technicians.Where(s => s.Specialty.Equals(Project.Specialty));
                technicians = technicians.Where(s => s.Level.Equals(Project.Level) || s.Level.Equals("Avanzado"));
            }
            Technician = await technicians.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FindAsync(id);
            TechnicianSelected = await _context.Technician.FindAsync(id);

            if (Project != null)
            {
                ProjectAssigned NewProject = new ProjectAssigned();
                NewProject.ID = Project.ID;
                NewProject.Specialty = Project.Specialty;
                NewProject.Level = Project.Level;
                NewProject.Description = Project.Description;
                NewProject.NHours = Project.NHours;
                NewProject.Technician = TechnicianSelected;

                _context.Project.Remove(Project);
                _context.ProjectAssigned.Add(NewProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}