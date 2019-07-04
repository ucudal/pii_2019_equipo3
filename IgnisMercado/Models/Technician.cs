using System;
using System.ComponentModel.DataAnnotations;

/* 
Technicians hereda de Person, tiene los atributos 
de dicha clase abstracta y a su vez tiene atributos 
más específicos de los técnicos.  
*/

namespace RazorPagesIgnis.Models
{
    public class Technician : Person
    {
    public string Level { set; get;}
    public string Specialty { set; get;}
    }
}