using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hw2.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(4449))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(4983))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedDate", "Email", "LastActivity", "Name", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5173), "admin@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yunus", "1234", "admin", "admin" },
                    { 2, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5178), "viewer@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emre", "1234", "viewer", "viwer" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "AccountId", "CreatedDate", "DateOfBirth", "Description", "Email", "FirstName", "LastName", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5284), new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5284), "Admin Accouunt'a bağlı person 1 ", "emre@gmail.com", "Yunus Emre", "Savan", "1234567", new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5285) },
                    { 2, 1, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5286), new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5286), "Admin Accouunt'a bağlı person 2 ", "hasan@gmail.com", "Hasan", "Savan", "213123", new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5287) },
                    { 3, 2, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5288), new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5288), "Viewer Accouunt'a bağlı person 1 ", "kerem@gmail.com", "Kerem", "Savan", "64745", new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5288) },
                    { 4, 2, new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5289), new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5290), "Viewer Accouunt'a bağlı person 2 ", "cihangir@gmail.com", "Cihangir", "Savan", "12345435436467", new DateTime(2023, 4, 14, 9, 13, 17, 418, DateTimeKind.Local).AddTicks(5290) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
