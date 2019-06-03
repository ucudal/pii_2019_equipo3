using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Technician : Person
    {
    public string Level { set; get;}
    public string Specialty { set; get;}
    public string Status { set; get;}
    }
}