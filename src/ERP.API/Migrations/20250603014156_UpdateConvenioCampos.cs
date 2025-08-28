using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConvenioCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Convenios_ConvenioId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_PacientesConvenios_Convenios_ConvenioId",
                table: "PacientesConvenios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Convenios",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Convenios");

            migrationBuilder.RenameTable(
                name: "Convenios",
                newName: "Convenio");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Convenio",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Convenio",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Convenio");

            migrationBuilder.RenameTable(
                name: "Convenio",
                newName: "Convenios");

            migrationBuilder.UpdateData(
                table: "Convenios",
                keyColumn: "Cnpj",
                keyValue: null,
                column: "Cnpj",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Convenios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Convenios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Convenios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Convenios",
                table: "Convenios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Convenios_ConvenioId",
                table: "Agendamentos",
                column: "ConvenioId",
                principalTable: "Convenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacientesConvenios_Convenios_ConvenioId",
                table: "PacientesConvenios",
                column: "ConvenioId",
                principalTable: "Convenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
