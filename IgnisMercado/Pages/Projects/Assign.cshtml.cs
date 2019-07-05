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
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public AssignModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<Technician> Technician { get;set; }

        public Project Project { get; set; }
        public IList<Project> Projects { get; set; }

        public string TechnicianID;
        public Technician TechnicianSelected;

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
        public async Task<IActionResult> OnPostAsync(int? id, string technicianID)
        {
            if (id == null || technicianID == null) 
            {
                return NotFound();
            }

            Projects = await _context.Project
                .Include(d => d.Client).ToListAsync();
            
            Projects = Projects.Where(s => s.ID.Equals(id)).ToList();;

            Project = Projects[0];

            TechnicianSelected = await _context.Technician.FindAsync(technicianID);

            if (Project != null && TechnicianSelected != null)
            {
                ProjectAssigned NewProject = new ProjectAssigned();
                NewProject.Specialty = Project.Specialty;
                NewProject.Level = Project.Level;
                NewProject.Description = Project.Description;
                NewProject.NHours = Project.NHours;
                NewProject.Technician = TechnicianSelected;
                NewProject.Client = Project.Client;

                _context.ProjectAssigned.Add(NewProject);
                _context.Project.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}