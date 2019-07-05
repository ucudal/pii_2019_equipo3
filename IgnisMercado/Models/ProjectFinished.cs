
/* 
ProjectFinished hereda de la interface IProject ya que es un tipo
 de projecto (finalizados) tiene los atributos de dicha interface 
 y se le agregan dos atributos mas especificos de esta clase. 
*/

namespace RazorPagesIgnis.Models
{
    public class ProjectFinished
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int NHours { get; set; }
        public Client Client { get; set; }
        public Technician Technician { set; get;}
        public Feedback Feedback { get; set; }
    }
}