using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProcedimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

    
        }
    }
}
