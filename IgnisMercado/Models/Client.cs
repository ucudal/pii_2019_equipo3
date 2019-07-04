using System.Collections.Generic;
using RazorPagesIgnis.Areas.Identity.Data;

/* 
Client hereda de AplicationUser y esta a su vez hereda de la clase IdentityUser,
 tiene los atributos de dicha clase y a su vez tiene una lista de projectos.  
*/

namespace RazorPagesIgnis.Models
{
    public class Client : ApplicationUser
    {
        public IList<Project> Projects = new List<Project>();
    }
}