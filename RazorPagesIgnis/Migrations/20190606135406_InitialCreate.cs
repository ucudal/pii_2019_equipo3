﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesIgnis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(nullable: true),
                    Positive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Specialty = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Mail = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssigned",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TechnicianID = table.Column<int>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssigned", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectAssigned_Technician_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technician",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFinished",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FeedbackID = table.Column<int>(nullable: true),
                    TechnicianID = table.Column<int>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFinished", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectFinished_Feedback_FeedbackID",
                        column: x => x.FeedbackID,
                        principalTable: "Feedback",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFinished_Technician_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technician",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssigned_TechnicianID",
                table: "ProjectAssigned",
                column: "TechnicianID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFinished_FeedbackID",
                table: "ProjectFinished",
                column: "FeedbackID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFinished_TechnicianID",
                table: "ProjectFinished",
                column: "TechnicianID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectAssigned");

            migrationBuilder.DropTable(
                name: "ProjectFinished");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Technician");
        }
    }
}
