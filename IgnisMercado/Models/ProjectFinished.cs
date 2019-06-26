using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished : IProject
    {
        public Technician Technician { set; get;}
        public Feedback Feedback { get; set; }
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int NHours { get; set; }
    }
}