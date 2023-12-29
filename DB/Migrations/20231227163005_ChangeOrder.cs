using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "Operacoon",
                table: "Ordenes",
                newName: "Operacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operacion",
                table: "Ordenes",
                newName: "Operacoon");

            migrationBuilder.AddColumn<double>(
                name: "MontoTotal",
                table: "Ordenes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
