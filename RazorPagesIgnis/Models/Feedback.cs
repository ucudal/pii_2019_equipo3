using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class Feedback
    {
        public Feedback(string comentario, bool positivo)
        {
            this.Comentario = comentario;
            this.Positivo = positivo;
        }
        public String Comentario { set; get;}
        public bool Positivo { set; get;}
    }   
}