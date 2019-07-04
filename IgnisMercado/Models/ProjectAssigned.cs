using System;
using System.ComponentModel.DataAnnotations;

/* 
ProjectAssigned hereda de la interface IProject ya que es un tipo
 de projecto (asigandos) tiene los atributos de dicha interface 
 y se le agrega un atributo mas especifico de esta clase. 
*/

namespace RazorPagesIgnis.Models
{
    public class ProjectAssigned
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int NHours { get; set; }
        public Client Client { get; set; }
        public Technician Technician { set; get;}

    }
}