using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
/* 
La clase ApplicationUser hereda de la clase IdentityUser(clase base) y a su vez 
es la clase base dos clases que comparten atributos más generales 
(relación de generalización-especialización)y a su vez esto favorece la reutilización de código. 
Esta clase también nos sirve en caso de que se quiera crear un tipo de usuario nuevo en el futuro, esta
abierta a la extensión y cerrada a la modificación (open/closed principle).  
*/

namespace RazorPagesIgnis.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set;}


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime DOB { get; set; }
        
        /*
         Es necesario tener acceso a IdentityManager para poder buscar el rol de este usuario; esta propiedad se asigna cada vez que se
         cambia el rol usando IdentityManager para poder buscar por rol después cuando no hay acceso a IdentityManager. La propiedad
         puede ser null para los usuarios que todavía no tienen un rol asignado.
        */

        public string Role { get; private set; }
        /* 
        El IdentityManager que se recibe como argumento no se usa en el método; sólo fuera a que el rol del usuario sea cambiado cuando
        existe en el contexto una instancia válida de IdentityManager.
        */
        public void AssignRole(UserManager<ApplicationUser> identityManager, string role)
        {
            if (identityManager == null)
            {
                throw new ArgumentNullException("identityManager");
            }

            this.Role = role;
        }
    }
}
