using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class Client : ProjectHolder
    {
        public Client(string name, int age, string mail, string password) : base(name, age, mail, password)
        {
        }
        public IList<Project> Projects = new List<Project>();

        public override void AddProject(Project project)
        {
            this.Projects.Add(project);
        }       
    }
}