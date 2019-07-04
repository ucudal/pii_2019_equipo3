using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

/* 
Client hereda de Person, tiene los atributos 
de dicha clase abstracta y a su vez tiene una lista de projectos.  
*/


namespace RazorPagesIgnis.Models
{
    public class Client : Person
    {
        public IList<Project> Projects = new List<Project>();


    }
}