using System;

namespace RazorPagesIgnis.Models
{
    public class Project : IProject
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int NHours { get; set; }
    }
}