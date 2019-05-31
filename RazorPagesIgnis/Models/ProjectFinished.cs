using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished : ProjectAssigned
    {
        public ProjectFinished(string specialty, string level, string description, Client client, bool finished, Technician technician, Feedback feedback) : base(specialty, level, description, client, finished, technician)
        {
            this.Feedback = feedback;
        }
        public Feedback Feedback { set; get;}
    }
}