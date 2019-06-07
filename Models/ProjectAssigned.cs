using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigned : IProject
    {
        public Technician Technician { set; get;}
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
    }
}