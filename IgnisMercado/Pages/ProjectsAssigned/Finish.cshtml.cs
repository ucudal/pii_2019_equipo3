using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Areas.Identity.Data;

namespace RazorPagesIgnis.Pages.ProjectsFinished
{
    public class FinishModel : PageModel
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;

        public FinishModel(RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectAssigned Project { get; set; }

        public Boolean Positive { get; set; }

        public String Comment { get; set; }
        public IList<ProjectAssigned> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project = await _context.ProjectAssigned.FindAsync(id);


            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, Boolean Positive, String Comment)
        {
            if (id == null)
            {
                return NotFound();
            }
            Feedback Feedback = new Feedback();
            Feedback.Positive = Positive;
            Feedback.Comment = Comment;

            Projects = await _context.ProjectAssigned
                .Include(e => e.Technician)
                .Include(d => d.Client).ToListAsync();
            
            Projects = Projects.Where(s => s.ID.Equals(id)).ToList();;

            Project = Projects[0];
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Project != null)
            {
                _context.Feedback.Add(Feedback);

                ProjectFinished NewProject = new ProjectFinished();
                NewProject.ID = Project.ID;
                NewProject.Specialty = Project.Specialty;
                NewProject.Level = Project.Level;
                NewProject.Description = Project.Description;
                NewProject.NHours = Project.NHours;
                NewProject.Technician = Project.Technician;
                NewProject.Client = Project.Client;
                NewProject.Feedback = Feedback;

                _context.ProjectAssigned.Remove(Project);
                _context.ProjectFinished.Add(NewProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}