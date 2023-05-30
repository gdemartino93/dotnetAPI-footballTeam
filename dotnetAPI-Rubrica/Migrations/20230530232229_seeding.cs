using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetAPI_footballTeam.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ContractExpiration", "DateOfBirth", "Lastname", "Name", "Role", "TeamId", "Value" },
                values: new object[] { 4, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hazard", "Eden", "Centrocampista", null, 100m });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ApplicationUserId", "City", "Name", "Stadium", "State" },
                values: new object[,]
                {
                    { 1, "70b76440-7470-44ee-a34e-8339ed2c844d", "Madrid", "Real Madrid", "Santiago Bernabeu", "Spagna" },
                    { 2, "eb6fe828-ac5a-4f9e-b7e5-f8e2729f3b8d", "Milano", "Ac Milan", "San Siro", "Italia" },
                    { 3, "fc20aa2e-b2ad-41fa-9f8c-7924445ca387", "Londra", "Chelsea", "Stamford Bridge", "Inghilterra" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ContractExpiration", "DateOfBirth", "Lastname", "Name", "Role", "TeamId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benzema", "Karim", "Attaccante", 1, 50m },
                    { 2, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibrahimovic", "Zlatan", "Attaccante", 2, 5m },
                    { 3, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kante", "N'Golo", "Centrocampista", 3, 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
