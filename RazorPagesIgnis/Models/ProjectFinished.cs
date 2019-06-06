using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished : ProjectAssigned
    {
        public Feedback Feedback { set; get;}
    }
}