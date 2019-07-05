using System;

/* 
Esta clase cumple con SRP ya que la unica razon de cambio que 
tiene por ejemplo si se agrega un nuevo atributo.
*/
namespace RazorPagesIgnis.Models
{
    public class Feedback
    {
        public int ID { set; get; }
        public String Comment { set; get; }
        public bool Positive { set; get; }
    }   
}