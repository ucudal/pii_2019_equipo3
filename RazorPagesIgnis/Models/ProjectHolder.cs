using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public abstract class ProjectHolder : Person
    {
        public ProjectHolder(string name, int age, string mail, string password) : base(name, age, mail, password)
        {
        }
    public virtual void AddProject(Project project)
    {
    }
    }
}
