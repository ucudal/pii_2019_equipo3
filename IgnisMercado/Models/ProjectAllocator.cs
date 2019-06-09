<<<<<<< HEAD
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public abstract class ProjectAllocator
    {
        public IList<Project> Projects = new List<Project>();
        public void NewProject(string especialidad, string nivel, string descripcion,  Client cliente)
        {
            Project project = new Project(especialidad, nivel, descripcion, cliente, false);
            cliente.AddProject(project);
            this.Projects.Add(project);
        }
    }
=======
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public abstract class ProjectAllocator
    {
        public IList<Project> Projects = new List<Project>();
        public void NewProject(string especialidad, string nivel, string descripcion,  Client cliente)
        {
            Project project = new Project(especialidad, nivel, descripcion, cliente, false);
            cliente.AddProject(project);
            this.Projects.Add(project);
        }
    }
>>>>>>> master
}