using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public abstract class ProjectAllocator
    {
        public IList<Project> Projects = new List<Project>();
        public void NewProject(string specialty, string level, string description,  Client client)
        {
            Project project = new Project(specialty, level, description, client, false);
            client.AddProject(project);
            this.Projects.Add(project);
        }
    }
}