using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class LinkProjectClient
    {
        [Key]
        public int ProjectID { get; set; }

        [Key]
        public int ClientID { get; set; }

        [Required]
        public Project Project { get; set; }

        [Required]
        public Client Client { get; set; }
    }
}