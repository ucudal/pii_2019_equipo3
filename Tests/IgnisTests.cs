using System;
using Xunit;
using RazorPagesIgnis.Models;
using RazorPagesIgnis.Pages.Projects;
using RazorPagesIgnis.Areas.Identity.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Net.Http;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;


namespace Tests
{
    public class IgnisTests
    {
        private const int V = 12;

        [Fact]
        public void PersonNameTest()
        {
            Technician name1 = new Technician();
            Client name2 = new Client();
            name1.Name = "Juan Martinez";
            name2.Name = "Juan Perez";
            Assert.Equal("Juan Martinez",name1.Name);
            Assert.Equal("Juan Perez",name2.Name);
        }

        [Fact]
        public void PersonDateOfBirthTest()
        {
            Technician dob1 = new Technician();
            Client dob2 = new Client();
            dob1.DOB = DateTime.Parse("1998-10-05");
            dob2.DOB = DateTime.Parse("2000-10-05");
            Assert.Equal(DateTime.Parse("1998-10-05"),dob1.DOB);
            Assert.Equal(DateTime.Parse("2000-10-05"),dob2.DOB);
        }

        

        [Fact]
        public void TechnicianSpecialtyTest()
        {
            Technician specialty1 = new Technician();
            specialty1.Specialty = "Fotografo";
            Assert.Equal("Fotografo",specialty1.Specialty);
        }

        [Fact]
        public void TechnicianLevelTest()
        {
            Technician level1 = new Technician();
            level1.Level = "Avanzado";
            Assert.Equal("Avanzado",level1.Level);
        }
       

         [Fact]
        public void ProjectSpecialtyTest()
        {
            Project specialty1 = new Project();
            specialty1.Specialty = "Fotografo";
            Assert.Equal("Fotografo",specialty1.Specialty);
        }

        [Fact]
        public void ProjectLevelTest()
        {
            Project level1 = new Project();
            level1.Level = "Avanzado";
            Assert.Equal("Avanzado",level1.Level);
        }

        [Fact]
        public void ProjectDescriptionTest()
        {
            Project description1 = new Project();
            description1.Description = "-";
            Assert.Equal("-",description1.Description);
        }


        [Fact]
        public void CreateProjectTest()
        {
            Project proj = new Project();
            var id = 10;
            var desc = "Video Musical";
            var lev = "Basico";
            var spec = "Fotografo";
            var nh = 7;

            proj.ID = id;
            proj.Description = desc;
            proj.Level = lev;
            proj.Specialty = spec;
            proj.NHours = nh;

            Assert.Equal(id , proj.ID);
            Assert.Equal(desc , proj.Description);
            Assert.Equal(lev , proj.Level);
            Assert.Equal(spec , proj.Specialty);
            Assert.Equal(nh , proj.NHours);

        }



        [Fact]
        public void AddClientToProjectTest()
        {
            Client cliente = new Client();
            Project proj = new Project();

            cliente.Name = "Juan";
            cliente.DOB = DateTime.Parse("1998-10-05");

            proj.Client = cliente;

            Assert.Equal("Juan", proj.Client.Name);
            Assert.Equal(DateTime.Parse("1998-10-05"), proj.Client.DOB);
        }
    
        [Fact]
        public void FeedbackTest()
        {
            Feedback feed = new Feedback();
            ProjectFinished proj2 = new ProjectFinished();

            int id = 3;
            bool pos = true; 
            string com = "Buen Trabajo";

            feed.ID = id;
            feed.Comment = com;
            feed.Positive = pos;

            proj2.Feedback = feed;
            

            Assert.Equal(feed, proj2.Feedback);

        }

        [Fact]
        public void AssingTechnicianTest()
        {
            Technician tec = new Technician();
            ProjectAssigned proj1 = new ProjectAssigned();

            tec.Name = "Jose Martinez";

            proj1.Technician = tec;

            Assert.Equal("Jose Martinez", proj1.Technician.Name);

        }


   

    }
}
