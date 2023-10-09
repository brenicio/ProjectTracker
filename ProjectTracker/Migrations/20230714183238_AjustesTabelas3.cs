using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class AjustesTabelas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_Empresas_EmpresaId",
                table: "LogProcessos");

            migrationBuilder.DropIndex(
                name: "IX_LogProcessos_EmpresaId",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "LogProcessos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "LogProcessos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogProcessos_EmpresaId",
                table: "LogProcessos",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogProcessos_Empresas_EmpresaId",
                table: "LogProcessos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
