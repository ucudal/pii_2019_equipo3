using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class TechniciansDirectory
    {
        public IList<Technician> Technicians = new List<Technician>();
        public void AddTechnician(string name, int age, string mail, string password, string level, string specialty, string status)
        {
            Technician technician = new Technician(name, age, mail, password, level, specialty, status);
            this.Technicians.Add(technician);
        }
        public bool RemoveTechnician(string mail)
        {
            foreach(Technician technician in Technicians)
            {
                if (technician.Mail == mail)
                {
                    this.Technicians.Remove(technician);
                    return true;
                }
            }
            return false;
        }
    }
}