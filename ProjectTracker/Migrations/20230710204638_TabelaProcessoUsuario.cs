using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProcessoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogProcessos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "ProcessosUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtvItv = table.Column<int>(type: "int", nullable: false),
                    TempoDecorrido = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProcesso = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessosUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessosUsuario_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessosUsuario_Processos_IdProcesso",
                        column: x => x.IdProcesso,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessosUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessosUsuario_IdEmpresa",
                table: "ProcessosUsuario",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessosUsuario_IdProcesso",
                table: "ProcessosUsuario",
                column: "IdProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessosUsuario_IdUsuario",
                table: "ProcessosUsuario",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessosUsuario");

            migrationBuilder.DropColumn(
                name: "TempoDecorrido",
                table: "LogProcessos");
        }
    }
}
