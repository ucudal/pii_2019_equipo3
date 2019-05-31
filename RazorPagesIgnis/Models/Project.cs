using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesIgnis.Models
{
    public class Project
    {
        public Project(string specialty, string level, string description, Client client, bool finished)
        {
            this.Specialty = specialty;
            this.Level = level;
            this.Description = Description;
            this.Client = client;
            this.Finished = Finished;
        }
        public string Specialty { set; get;}
        public string Level { set; get;}
        public string Description { set; get;}
        public Client Client { set; get;}
        public bool Finished { set; get;}
    }
}