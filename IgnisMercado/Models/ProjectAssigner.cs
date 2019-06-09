using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigner
    {
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;
        public Technician Technician { set; get;}
        public Project Project { set; get;}
        public ProjectAssigner(Project project, Technician technician, RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
            Technician = technician;
            Project = project;
        }

        public async void Assigner()
        {
            if (Project != null)
            {
                ProjectAssigned NewProject = new ProjectAssigned();
                NewProject.ID = Project.ID;
                NewProject.Specialty = Project.Specialty;
                NewProject.Level = Project.Level;
                NewProject.Description = Project.Description;
                NewProject.Client = Project.Client;
                NewProject.Technician = Technician;

                _context.Project.Remove(Project);
                _context.ProjectAssigned.Add(NewProject);
                await _context.SaveChangesAsync();
            }
        }
    }
}