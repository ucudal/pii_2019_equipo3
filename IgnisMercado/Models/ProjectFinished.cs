using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished : IProject
    {
        public Feedback Feedback { get; set; }
        public Technician Technician { get ; set; }
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
    }
}