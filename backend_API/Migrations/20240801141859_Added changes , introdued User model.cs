using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedchangesintroduedUsermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceAdvisorId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDueDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ServiceRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDispatched",
                table: "ServiceRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ServiceRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceAdvisorId",
                table: "Vehicles",
                column: "ServiceAdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ServiceAdvisors_ServiceAdvisorId",
                table: "Vehicles",
                column: "ServiceAdvisorId",
                principalTable: "ServiceAdvisors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ServiceAdvisors_ServiceAdvisorId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ServiceAdvisorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ServiceAdvisorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ServiceDueDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "IsDispatched",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ServiceRecords");
        }
    }
}
