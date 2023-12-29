using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class AddActivoOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Estados_EstadoId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Ordenes",
                newName: "IdEstado");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenes_EstadoId",
                table: "Ordenes",
                newName: "IX_Ordenes_IdEstado");

            migrationBuilder.AddColumn<int>(
                name: "IdActivo",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdActivo",
                table: "Ordenes",
                column: "IdActivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Activos_IdActivo",
                table: "Ordenes",
                column: "IdActivo",
                principalTable: "Activos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Estados_IdEstado",
                table: "Ordenes",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Activos_IdActivo",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Estados_IdEstado",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_IdActivo",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "IdActivo",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Ordenes",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenes_IdEstado",
                table: "Ordenes",
                newName: "IX_Ordenes_EstadoId");

            migrationBuilder.AddColumn<string>(
                name: "Activo",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Estados_EstadoId",
                table: "Ordenes",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
