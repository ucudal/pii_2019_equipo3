using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished : ProjectAssigned
    {
        public ProjectFinished(string especialidad, string nivel, string descripcion, Client cliente, bool terminado, Technician tecnico, Feedback feedback) : base(especialidad, nivel, descripcion, cliente, terminado, tecnico)
        {
            this.Feedback = feedback;
        }
        public Feedback Feedback { set; get;}
    }
}