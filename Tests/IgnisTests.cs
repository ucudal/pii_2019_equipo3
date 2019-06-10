using System;
using Xunit;
using RazorPagesIgnis.Models;


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
        public void PersonSpecialtyTest()
        {
            Technician specialty1 = new Technician();
            specialty1.Specialty = "Fotografo";
            Assert.Equal("Fotografo",specialty1.Specialty);
        }

        [Fact]
        public void PersonLevelTest()
        {
            Technician level1 = new Technician();
            level1.Level = "Avanzado";
            Assert.Equal("Avanzado",level1.Level);
        }
    }
}
