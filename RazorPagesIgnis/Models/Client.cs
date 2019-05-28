using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class Client : ProjectHolder
    {
        public Client(string nombre, int edad, string mail, string contraseña) : base(nombre, edad, mail, contraseña)
        {
        }
        public IList<Project> Projects = new List<Project>();

        public override void AddProject(Project project)
        {
            this.Projects.Add(project);
        }       
    }
}