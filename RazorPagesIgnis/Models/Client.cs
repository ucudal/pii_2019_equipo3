using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class Client : Person
    {
        public IList<Project> Projects = new List<Project>();


    }
}