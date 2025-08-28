using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacionamentoAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId1",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Profissionais_ProfissionalId1",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_PacienteId1",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ProfissionalId1",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId1",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ProfissionalId1",
                table: "Agendamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PacienteId1",
                table: "Agendamentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalId1",
                table: "Agendamentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId1",
                table: "Agendamentos",
                column: "PacienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ProfissionalId1",
                table: "Agendamentos",
                column: "ProfissionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId1",
                table: "Agendamentos",
                column: "PacienteId1",
                principalTable: "Pacientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Profissionais_ProfissionalId1",
                table: "Agendamentos",
                column: "ProfissionalId1",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
