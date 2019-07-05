using System.Collections.Generic;
using RazorPagesIgnis.Areas.Identity.Data;

/* 
Client hereda de AplicationUser y esta a su vez hereda de la clase IdentityUser,
 tiene los atributos de dicha clase. 
*/

namespace RazorPagesIgnis.Models
{
    public class Client : ApplicationUser
    {
    }
}