using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Technical.Interview.WebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcasAutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PaisOrigen = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SitioWeb = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MarcasAutos",
                columns: new[] { "Id", "Nombre", "PaisOrigen", "SitioWeb" },
                values: new object[,]
                {
                    { new Guid("79c7dbf3-9a28-4476-832a-ee7af263c43f"), "Ford", "United States", "https://www.ford.com/" },
                    { new Guid("87209a57-138b-4f7a-8a7d-4add1045296d"), "Volkswagen", "Germany", "https://www.vw.com/" },
                    { new Guid("c9181437-053c-4217-80c1-08ed563d0b40"), "Toyota", "Japan", "https://www.toyota.com/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcasAutos");
        }
    }
}
