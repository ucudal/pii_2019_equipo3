using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigned : Project
    {
        public ProjectAssigned(string specialty, string level, string description, Client client, bool finished, Technician technician) : base(specialty, level, description, client, finished)
        {
            this.Technician = technician;
        }
        public Technician Technician { set; get;}
    }
}