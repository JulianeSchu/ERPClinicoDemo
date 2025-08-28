using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeDataVinculoComoCalculado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "PacientesConvenios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoConsulta",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalId",
                table: "Procedimentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "PacientesConvenios",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "TipoConsulta",
                table: "Agendamentos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Agendamentos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
