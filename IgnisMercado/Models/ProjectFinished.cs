/* 
Esta clase cumple con SRP ya que la unica razon de cambio que 
tiene por ejemplo si se agrega un nuevo atributo.
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