using RazorPagesIgnis.Areas.Identity.Data;

/* 
Technicians hereda de  ApplicationUser y esta a su vez hereda de la clase IdentityUser,
tiene los atributos de dicha clase y a su vez tiene atributos 
más específicos de los técnicos; dicha herencia se justifica debido a que todo 
tecnico necesita los atributos/operaciones declaradasen ApplicationUser por lo que verifican el ISP.
Cumple con SRP ya que la unica razon de cambio que tiene por ejemplo si se agrega un nuevo atributo.
Esta clase cumple con open/close ya que esta abierta a extension (asi como esta extiende a ApplicationUser) 
y esta cerrada a modificacion porque no es necesario agregar metodos, atributos, etc. para que
la clase funcione correctamete.  
*/
namespace RazorPagesIgnis.Models
{
    public class Technician : ApplicationUser
    {
        public string Level { set; get;}
        public string Specialty { set; get;}
    }
}