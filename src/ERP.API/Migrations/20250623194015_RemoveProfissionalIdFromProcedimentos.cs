using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProfissionalIdFromProcedimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            // Depois: remova o índice (se houver)
            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_ProfissionalId",
                table: "Procedimentos");

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

        }
    }
}
