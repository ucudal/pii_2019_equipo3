using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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