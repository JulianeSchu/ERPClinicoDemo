using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAgendamentosCollectionToConvenio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId1",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_ProfissionalId1",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "ProfissionalId1",
                table: "Procedimentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalId1",
                table: "Procedimentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ProfissionalId1",
                table: "Procedimentos",
                column: "ProfissionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId1",
                table: "Procedimentos",
                column: "ProfissionalId1",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
