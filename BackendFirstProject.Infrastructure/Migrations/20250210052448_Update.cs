using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFirstProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportedTo",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ReportedTo",
                table: "Employees",
                newName: "ReportedToEmployeeNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ReportedTo",
                table: "Employees",
                newName: "IX_Employees_ReportedToEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportedToEmployeeNumber",
                table: "Employees",
                column: "ReportedToEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportedToEmployeeNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ReportedToEmployeeNumber",
                table: "Employees",
                newName: "ReportedTo");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ReportedToEmployeeNumber",
                table: "Employees",
                newName: "IX_Employees_ReportedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportedTo",
                table: "Employees",
                column: "ReportedTo",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
