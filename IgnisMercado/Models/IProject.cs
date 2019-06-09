using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public interface IProject
    {
        int ID{ set; get; }
        string Specialty { set; get; }
        string Level { set; get; }
        string Description { set; get; }
        String Client { set; get; }
    }
}