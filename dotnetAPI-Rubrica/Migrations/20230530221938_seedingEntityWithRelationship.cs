using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetAPI_footballTeam.Migrations
{
    /// <inheritdoc />
    public partial class seedingEntityWithRelationship : Migration
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
                    { 1, "07582b52-97e9-48bd-897b-3e87144ab035", "Madrid", "Real Madrid", "Santiago Bernabeu", "Spagna" },
                    { 2, "b5777d27-49c9-4999-951b-a33ddc4f65aa", "Milano", "Ac Milan", "San Siro", "Italia" },
                    { 3, "eeab3023-3f38-4839-95b4-bfb4bbe9c466", "Londra", "Chelsea", "Stamford Bridge", "Inghilterra" }
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
