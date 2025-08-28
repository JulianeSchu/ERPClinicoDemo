using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class AlteraPacienteConvenioParaDataVinculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "PacientesConvenios");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "PacientesConvenios",
                newName: "DataVinculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataVinculo",
                table: "PacientesConvenios",
                newName: "DataInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "PacientesConvenios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
