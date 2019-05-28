using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class ProjectHolder : Person
    {
        public ProjectHolder(string nombre, int edad, string mail, string contraseña) : base(nombre, edad, mail, contraseña)
        {
        }
    public virtual void AddProject(Project project)
    {
    }
    }
}
