using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSexoToPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CRM",
                table: "Profissionais",
                newName: "Crm");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Profissionais",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Crm",
                table: "Profissionais",
                newName: "CRM");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Profissionais",
                newName: "CPF");
        }
    }
}
