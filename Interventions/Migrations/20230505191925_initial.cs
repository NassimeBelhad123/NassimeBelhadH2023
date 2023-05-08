using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Interventions.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateProbleme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noTypeProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courrielConfirmation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noUnite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesProbleme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descriptionTypeProbleme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProbleme", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypesProbleme",
                columns: new[] { "Id", "descriptionTypeProbleme" },
                values: new object[,]
                {
                    { 1, "Problème d'écran" },
                    { 2, "Problème avec le disque dur" },
                    { 3, "Problème de connexion réseau" },
                    { 4, "Problème avec la souris" },
                    { 5, "Problème de clavier" },
                    { 6, "Problème d'ouverture du logiciel Ms-Word" },
                    { 7, "Problème d'ouverture du logiciel Ms-Excel" },
                    { 8, "Problème d'imprimante" },
                    { 9, "Problème entre la chaise et le clavier..." },
                    { 10, "Autre" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problemes");

            migrationBuilder.DropTable(
                name: "TypesProbleme");
        }
    }
}
