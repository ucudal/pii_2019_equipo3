using System.Collections.Generic;
using RazorPagesIgnis.Areas.Identity.Data;

/* 
Client hereda de AplicationUser y esta a su vez hereda de la clase IdentityUser,
tiene los atributos de dicha clase y a su vez tiene una lista de projectos; dicha herencia
se justifica debido a que todo cliente necesita los atributos/operaciones declaradas
en ApplicationUser por lo que verifican el ISP.
Tambien cumple con SRP ya que la unica razon de cambio que tiene es si se 
cambia alguno de sus atributos por ejemplo si quieren agregar atributos.
Esta clase cumple con open/close ya que esta abierta a extension (asi como esta extiende a ApplicationUser) 
y esta cerrada a modificacion porque no es necesario agregar metodos, atributos, etc. para que
la clase funcione correctamete.
*/

namespace RazorPagesIgnis.Models
{
    public class Client : ApplicationUser{}
}