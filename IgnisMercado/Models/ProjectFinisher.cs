using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinisher
    {
        private readonly RazorPagesIgnis.Areas.Identity.Data.IdentityContext _context;
        public Feedback Feedback { set; get;}
        public ProjectAssigned ProjectAssigned { set; get;}
        public ProjectFinisher(ProjectAssigned projectAssigned, Feedback feedback, RazorPagesIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
            Feedback = feedback;
            ProjectAssigned = projectAssigned;
        }

        public async void Finisher()
        {
            if (ProjectAssigned != null)
            {
                ProjectFinished NewProject = new ProjectFinished();
                NewProject.ID = ProjectAssigned.ID;
                NewProject.Specialty = ProjectAssigned.Specialty;
                NewProject.Level = ProjectAssigned.Level;
                NewProject.Description = ProjectAssigned.Description;
                NewProject.NHours = ProjectAssigned.NHours;
                NewProject.Feedback = Feedback;

                _context.ProjectAssigned.Remove(ProjectAssigned);
                _context.ProjectFinished.Add(NewProject);
                await _context.SaveChangesAsync();
            }
        }
    }
}