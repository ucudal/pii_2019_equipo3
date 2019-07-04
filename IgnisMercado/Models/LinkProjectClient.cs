using System.ComponentModel.DataAnnotations;


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