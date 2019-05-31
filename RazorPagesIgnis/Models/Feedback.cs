using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class Feedback
    {
        public Feedback(string comment, bool positive)
        {
            this.Comment = comment;
            this.Positive = positive;
        }
        public String Comment { set; get;}
        public bool Positive { set; get;}
    }   
}