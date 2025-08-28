using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeRelacionamentosAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
