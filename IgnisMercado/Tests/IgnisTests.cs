using System;
using Xunit;
using RazorPagesIgnis.Models;
using System.Collections.Generic;


namespace Tests
{
    public class IgnisTests
    {

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
        public void PersonAgeTest()
        {
            Technician age1 = new Technician();
            Client age2 = new Client();
            age1.Age = 12;
            age2.Age = 13;
            Assert.Equal(12,age1.Age);
            Assert.Equal(13,age2.Age);
        }

        [Fact]
        public void PersonMailTest()
        {
            Technician mail1 = new Technician();
            Client mail2 = new Client();
            mail1.Mail = "example1@example.com";
            mail2.Mail = "example2@example.com";
            Assert.Equal("example1@example.com",mail1.Mail);
            Assert.Equal("example2@example.com",mail2.Mail);
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
        public void ClientListTest()
        {
            Project proy = new Project();
            Project proy2 = new Project();
            Client list = new Client();
            Assert.Equal(0,list.Projects.Count);
            list.Projects.Add(proy);
            Assert.Equal(1,list.Projects.Count);
            list.Projects.Remove(proy);
            Assert.Equal(0,list.Projects.Count);
            list.Projects.Add(proy);
            list.Projects.Add(proy2);
            list.Projects.Clear();
            Assert.Equal(0,list.Projects.Count);
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

/* 
        [Fact]
        public void ProjectAssignerTest()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<RazorPagesIgnisContext> options = new Microsoft.EntityFrameworkCore.DbContextOptions<RazorPagesIgnisContext>();
            RazorPagesIgnisContext razorPages = new RazorPagesIgnisContext(options);
            Project proy = new Project();
            Technician tech = new Technician();
            ProjectAssigner assigner = new ProjectAssigner(proy,tech,razorPages);
            assigner.Assigner();
            Assert.Equal(null,razorPages.Project.Find(proy));
            Assert.Equal(true,razorPages.ProjectAssigned.Find(proy).Equals(proy));
        }
*/
    }
}
