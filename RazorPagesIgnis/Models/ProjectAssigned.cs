using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigned : Project
    {
        public Technician Technician { set; get;}
    }
}