<<<<<<< HEAD
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class TechniciansDirectory
    {
        public IList<Technician> Technicians = new List<Technician>();
        public void AddTechnician(string nombre, int edad, string mail, string contraseña, string nivel, string especialidad, string estado)
        {
            Technician technician = new Technician(nombre, edad, mail, contraseña, nivel, especialidad, estado);
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
=======
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class TechniciansDirectory
    {
        public IList<Technician> Technicians = new List<Technician>();
        public void AddTechnician(string nombre, int edad, string mail, string contraseña, string nivel, string especialidad, string estado)
        {
            Technician technician = new Technician(nombre, edad, mail, contraseña, nivel, especialidad, estado);
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
>>>>>>> master
}