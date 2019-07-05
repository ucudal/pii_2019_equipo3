
/* 
Project hereda de la interface IProject ya que es un tipo de 
projecto (publicados) tiene los atributos de dicha interface. 
*/
namespace RazorPagesIgnis.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int NHours { get; set; }
        public Client Client { get; set; }
    }
}