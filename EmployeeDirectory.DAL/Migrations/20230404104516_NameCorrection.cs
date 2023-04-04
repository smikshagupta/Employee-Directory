using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDirectory.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NameCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designatons_DesignatonID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Designatons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignatonID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignatonID",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationID",
                table: "Employees",
                column: "DesignationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designations_DesignationID",
                table: "Employees",
                column: "DesignationID",
                principalTable: "Designations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designations_DesignationID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "DesignatonID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Designatons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designatons", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignatonID",
                table: "Employees",
                column: "DesignatonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designatons_DesignatonID",
                table: "Employees",
                column: "DesignatonID",
                principalTable: "Designatons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
