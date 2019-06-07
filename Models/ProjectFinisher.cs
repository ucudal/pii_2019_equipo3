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
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;
        public Feedback Feedback { set; get;}
        public ProjectAssigned Project { set; get;}
        public ProjectFinisher(ProjectAssigned project, Feedback feedback, RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
            Feedback = feedback;
            Project = project;
        }

        public async void Finisher()
        {
            if (Project != null)
            {
                ProjectFinished NewProject = new ProjectFinished();
                NewProject.ID = Project.ID;
                NewProject.Specialty = Project.Specialty;
                NewProject.Level = Project.Level;
                NewProject.Description = Project.Description;
                NewProject.Client = Project.Client;
                NewProject.Technician = Project.Technician;
                NewProject.Feedback = Feedback;

                _context.ProjectAssigned.Remove(Project);
                _context.ProjectFinished.Add(NewProject);
                await _context.SaveChangesAsync();
            }
        }
    }
}