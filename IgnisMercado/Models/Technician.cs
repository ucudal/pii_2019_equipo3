using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using RazorPagesIgnis.Areas.Identity.Data;


/* 
Technicians hereda de Person, tiene los atributos 
de dicha clase abstracta y a su vez tiene atributos 
más específicos de los técnicos.  
*/

namespace RazorPagesIgnis.Models
{
    public class Technician : ApplicationUser
    {
        public string Level { set; get;}
        public string Specialty { set; get;}
    }
}