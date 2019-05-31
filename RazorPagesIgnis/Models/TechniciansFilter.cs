using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesIgnis.Models
{
    public class TechnicianFilter
    {
        public TechnicianFilter(Project project)
        {
            this.Project = project;
        }

        public Project Project { set; get;}
        public IList<Technician> FilteredTechnicians = new List<Technician>();

        public void Filter()
        {
            TechniciansDirectory Directory = new TechniciansDirectory();

            foreach(Technician technician in Directory.Technicians)
            {
                if(this.Project.Level == technician.Level && this.Project.Specialty == technician.Specialty)
                {
                    this.FilteredTechnicians.Add(technician);
                }
            }
        }
    }
}