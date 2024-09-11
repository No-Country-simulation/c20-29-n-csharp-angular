using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_TipoOrganizacion",
                table: "Refugios",
                newName: "TipoOrganizacion");

            migrationBuilder.RenameColumn(
                name: "AñoFundacion",
                table: "Refugios",
                newName: "AnioFundacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoOrganizacion",
                table: "Refugios",
                newName: "_TipoOrganizacion");

            migrationBuilder.RenameColumn(
                name: "AnioFundacion",
                table: "Refugios",
                newName: "AñoFundacion");
        }
    }
}
