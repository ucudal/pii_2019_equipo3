using System;


namespace RazorPagesIgnis.Models
{
    public class Feedback
    {
        public int ID { set; get; }
        public String Comment { set; get; }
        public bool Positive { set; get; }
    }   
}