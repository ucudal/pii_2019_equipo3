using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Project
    {
        public Project(string especialidad, string nivel, string descripcion, Client cliente, bool terminado)
        {
            this.Especialidad = especialidad;
            this.Nivel = nivel;
            this.Descripcion = descripcion;
            this.Cliente = cliente;
            this.Terminado = terminado;
        }
        public string Especialidad { set; get;}
        public string Nivel { set; get;}
        public string Descripcion { set; get;}
        public Client Cliente { set; get;}
        public bool Terminado { set; get;}
    }
}