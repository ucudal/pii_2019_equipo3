
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class LinkProjectTechnician
    {
        [Key]
        public int ProjectID { get; set; }

        [Key]
        public int TechnicianID { get; set; }

        [Required]
        public Project Project { get; set; }

        [Required]
        public Technician Technician { get; set; }
    }
}