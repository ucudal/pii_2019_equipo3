﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Migrations
{
    [DbContext(typeof(RazorPagesIgnisContext))]
    partial class RazorPagesIgnisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("RazorPagesIgnis.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<bool>("Positive");

                    b.HasKey("ID");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Client");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Level");

                    b.Property<string>("Specialty");

                    b.HasKey("ID");

                    b.ToTable("Project");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Project");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.Technician", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Level");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Specialty");

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.ToTable("Technician");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.ProjectAssigned", b =>
                {
                    b.HasBaseType("RazorPagesIgnis.Models.Project");

                    b.Property<int?>("TechnicianID");

                    b.HasIndex("TechnicianID");

                    b.HasDiscriminator().HasValue("ProjectAssigned");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.ProjectFinished", b =>
                {
                    b.HasBaseType("RazorPagesIgnis.Models.ProjectAssigned");

                    b.Property<int?>("FeedbackID");

                    b.HasIndex("FeedbackID");

                    b.HasDiscriminator().HasValue("ProjectFinished");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.ProjectAssigned", b =>
                {
                    b.HasOne("RazorPagesIgnis.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianID");
                });

            modelBuilder.Entity("RazorPagesIgnis.Models.ProjectFinished", b =>
                {
                    b.HasOne("RazorPagesIgnis.Models.Feedback", "Feedback")
                        .WithMany()
                        .HasForeignKey("FeedbackID");
                });
#pragma warning restore 612, 618
        }
    }
}
