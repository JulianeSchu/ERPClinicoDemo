using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTabelaProcedimentoProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.DropTable(
                name: "ProcedimentosProfissionais");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfissionalId",
                table: "Procedimentos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProcedimentoId",
                table: "Agendamentos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ProcedimentoId",
                table: "Agendamentos",
                column: "ProcedimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Procedimentos_ProcedimentoId",
                table: "Agendamentos",
                column: "ProcedimentoId",
                principalTable: "Procedimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Procedimentos_ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ProcedimentoId",
                table: "Agendamentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfissionalId",
                table: "Procedimentos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "ProcedimentosProfissionais",
                columns: table => new
                {
                    ProcedimentoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProfissionalId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentosProfissionais", x => new { x.ProcedimentoId, x.ProfissionalId });
                    table.ForeignKey(
                        name: "FK_ProcedimentosProfissionais_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedimentosProfissionais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosProfissionais_ProfissionalId",
                table: "ProcedimentosProfissionais",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Profissionais_ProfissionalId",
                table: "Procedimentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
