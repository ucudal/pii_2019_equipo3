using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Project
    {
        public int ID{ set; get; }
        public string Specialty { set; get; }
        public string Level { set; get; }
        public string Description { set; get; }
        public string Client { set; get; }
    }
}