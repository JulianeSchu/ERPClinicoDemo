using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAtivoToConvenios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Convenio_ConvenioId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesConvenios_Convenio_ConvenioId",
                table: "PacientesConvenios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Convenio",
                table: "Convenio");

            migrationBuilder.RenameTable(
                name: "Convenio",
                newName: "convenios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_convenios",
                table: "convenios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_convenios_ConvenioId",
                table: "Agendamentos",
                column: "ConvenioId",
                principalTable: "convenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesConvenios_convenios_ConvenioId",
                table: "PacientesConvenios",
                column: "ConvenioId",
                principalTable: "convenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_convenios_ConvenioId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesConvenios_convenios_ConvenioId",
                table: "PacientesConvenios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_convenios",
                table: "convenios");

            migrationBuilder.RenameTable(
                name: "convenios",
                newName: "Convenio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Convenio",
                table: "Convenio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Convenio_ConvenioId",
                table: "Agendamentos",
                column: "ConvenioId",
                principalTable: "Convenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesConvenios_Convenio_ConvenioId",
                table: "PacientesConvenios",
                column: "ConvenioId",
                principalTable: "Convenio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
