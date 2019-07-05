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
        public void PersonMailTest()
        {
            Technician mail1 = new Technician();
            Client mail2 = new Client();
            mail1.Email = "example1@example.com";
            mail2.Email = "example2@example.com";
            Assert.Equal("example1@example.com",mail1.EMail);
            Assert.Equal("example2@example.com",mail2.EMail);
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
        /*
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
        */

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


    public static class Utilities
    {
        public static DbContextOptions<IdentityContext> TestDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and
            // IServiceProvider that the context should resolve all of its
            // services from.
            var builder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
 

        [Fact]
        public async Task ProjectAssignTest()
        {
            using (var db = new IdentityContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var projId = 10;
                var expectedProject = new ProjectAssigned() { ID = projId};

                // Act
                var proj1 = new Project();
                await db.OnPostAsync(projId);

                // Assert
                var actualProject = await db.FindAsync<Action>(projId);
                Assert.Equal(expectedProject, actualProject);
            }
        }

        private delegate Task TestAction(IdentityContext context);
        private async Task PrepareTestContext(TestAction testAction)
        {
            // Database is in memory as long the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            try
            {
                connection.Open();

                var options = new DbContextOptionsBuilder<IdentityContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database and seeds with test data
                using (var context = new IdentityContext(options))
                {
                    context.Database.EnsureCreated();
                    SeedData.Initialize(context);

                    await testAction(context);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task ProjectFinisherTest()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var proj1 = new ProjectAssigned();
                
                

                // Act
                var feedback1 = new Feedback();
                await db.OnPostAsync(feedback1);

                // Assert
                var projFinished = await db.FindAsync<Action>(proj1);
                Assert.Equal(proj1, projFinished);
                Assert.Contains(projFinished, feedback1);
            }
        }

        [Fact]
        public async Task ProjectFinishedDeleteTest()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            
            {
                // Arrange
                var proj1 = new ProjectFinished();
                

                // Act
                await db.OnPostAsync(proj1);

                // Assert
                var proj1 = await db.FindAsync<Action>(proj1);
                Assert.Empty(proj1);
            }
        }


    }
}
