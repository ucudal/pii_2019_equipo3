using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigned : Project
    {
        public ProjectAssigned(string especialidad, string nivel, string descripcion, Client cliente, bool terminado, Technician tecnico) : base(especialidad, nivel, descripcion, cliente, terminado)
        {
            this.Tecnico = tecnico;
        }
        public Technician Tecnico { set; get;}
    }
}