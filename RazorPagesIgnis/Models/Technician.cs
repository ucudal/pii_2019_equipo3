using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Technician : ProjectHolder
    {
        public Technician(string nombre, int edad, string mail, string contraseña, string nivel, string especialidad, string estado) : base(nombre, edad, mail, contraseña)
        {
            this.Nivel = nivel;
            this.Especialidad = especialidad;
            this.Estado = estado;
        }
    
    public string Nivel { set; get;}
    public string Especialidad { set; get;}
    public string Estado { set; get;}
    }
}