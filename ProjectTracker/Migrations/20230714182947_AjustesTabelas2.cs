using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class AjustesTabelas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_Empresas_IdEmpresa",
                table: "LogProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_Processos_IdProcesso",
                table: "LogProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_Usuarios_IdUsuario",
                table: "LogProcessos");

            migrationBuilder.DropIndex(
                name: "IX_LogProcessos_IdEmpresa",
                table: "LogProcessos");

            migrationBuilder.DropIndex(
                name: "IX_LogProcessos_IdProcesso",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "DataCad",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "IdProcesso",
                table: "LogProcessos");

            migrationBuilder.RenameColumn(
                name: "DataCad",
                table: "ProcessosUsuario",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "LogProcessos",
                newName: "IdProcessoUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_LogProcessos_IdUsuario",
                table: "LogProcessos",
                newName: "IX_LogProcessos_IdProcessoUsuario");

            migrationBuilder.RenameColumn(
                name: "DataCad",
                table: "LogEmpresas",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "DataCad",
                table: "LogAreas",
                newName: "DataCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMovimento",
                table: "ProcessosUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "LogProcessos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogEmpresas",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogAreas",
                type: "time",
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

            migrationBuilder.AddForeignKey(
                name: "FK_LogProcessos_ProcessosUsuario_IdProcessoUsuario",
                table: "LogProcessos",
                column: "IdProcessoUsuario",
                principalTable: "ProcessosUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_Empresas_EmpresaId",
                table: "LogProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProcessos_ProcessosUsuario_IdProcessoUsuario",
                table: "LogProcessos");

            migrationBuilder.DropIndex(
                name: "IX_LogProcessos_EmpresaId",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "DataMovimento",
                table: "ProcessosUsuario");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "LogProcessos");

            migrationBuilder.DropColumn(
                name: "TempoDecorrido",
                table: "LogEmpresas");

            migrationBuilder.DropColumn(
                name: "TempoDecorrido",
                table: "LogAreas");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "ProcessosUsuario",
                newName: "DataCad");

            migrationBuilder.RenameColumn(
                name: "IdProcessoUsuario",
                table: "LogProcessos",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_LogProcessos_IdProcessoUsuario",
                table: "LogProcessos",
                newName: "IX_LogProcessos_IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "LogEmpresas",
                newName: "DataCad");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "LogAreas",
                newName: "DataCad");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCad",
                table: "LogProcessos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "LogProcessos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProcesso",
                table: "LogProcessos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LogProcessos_IdEmpresa",
                table: "LogProcessos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_LogProcessos_IdProcesso",
                table: "LogProcessos",
                column: "IdProcesso");

            migrationBuilder.AddForeignKey(
                name: "FK_LogProcessos_Empresas_IdEmpresa",
                table: "LogProcessos",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProcessos_Processos_IdProcesso",
                table: "LogProcessos",
                column: "IdProcesso",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProcessos_Usuarios_IdUsuario",
                table: "LogProcessos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
