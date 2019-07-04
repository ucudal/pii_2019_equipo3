using System;
using System.Text.RegularExpressions;

/* 
Creamos la clase abstracta Person como base ya que existen dos clases  
que comparten atributos más generales (relación de generalización-especialización)
y a su vez esto favorece la reutilización de código. Esta clase también nos 
sirve en caso de que se quiera crear un tipo de usuario nuevo en el futuro, esta
abierta a la extensión y cerrada a la modificación (open/closed principle).  
*/

namespace RazorPagesIgnis.Models
{
    public abstract class Person
    {
        public int ID { set; get; }
        public string Name {get; set;}
        public int Age { get; set; }
        public string Mail { get; set; }
    }
}