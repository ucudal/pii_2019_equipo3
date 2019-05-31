using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Technician : ProjectHolder
    {
        public Technician(string name, int age, string mail, string password, string level, string specialty, string status) : base(name, age, mail, password)
        {
            this.Level = level;
            this.Specialty = specialty;
            this.Status = status;
        }
    
    public string Level { set; get;}
    public string Specialty { set; get;}
    public string Status { set; get;}
    }
}