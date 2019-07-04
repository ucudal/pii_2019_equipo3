
/* 
Creamos esta interface como base ya que existen 3 tipos de proyectos distintos  
los cuales comparten atributos más generales (relación de generalización-especialización)
y a su vez esto favorece la reutilización de código. Esta interface también nos 
sirve en caso de que se quiera crear un tipo de proyecto nuevo en el futuro, 
tambien cumple con el principio open/closed ya que esta abierta a extension y cerrada a modificacion. 
*/

namespace RazorPagesIgnis.Models
{
    public interface IProject
    {
        int ID{ set; get; }
        string Specialty { set; get; }
        string Level { set; get; }
        string Description { set; get; }
        int NHours { set; get; }
    }
}