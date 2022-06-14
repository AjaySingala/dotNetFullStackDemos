using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPICodeFirstSample.Migrations
{
    public partial class EFCoreAPICodeFirstSampleModelsAddEmployeeGenderAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", "Male", "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 2L, new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.kirsten@gmail.com", "Jan", "Female", "Kirsten", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");
        }
    }
}
