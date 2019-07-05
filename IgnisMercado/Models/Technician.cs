
using RazorPagesIgnis.Areas.Identity.Data;

/* 
Technicians hereda de  ApplicationUser y esta a su vez hereda de la clase IdentityUser,
tiene los atributos de dicha clase y a su vez tiene atributos 
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