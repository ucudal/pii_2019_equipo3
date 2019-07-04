using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using RazorPagesIgnis.Areas.Identity.Data;


/* 
Client hereda de Person, tiene los atributos 
de dicha clase abstracta y a su vez tiene una lista de projectos.  
*/


namespace RazorPagesIgnis.Models
{
    public class Client : ApplicationUser
    {
        public IList<Project> Projects = new List<Project>();
    }
}