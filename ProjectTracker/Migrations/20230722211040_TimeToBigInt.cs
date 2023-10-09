using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class TimeToBigInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TempoDecorrido",
                table: "ProcessosUsuario",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TempoDecorrido",
                table: "LogProcessos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TempoDecorrido",
                table: "LogEmpresas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TempoDecorrido",
                table: "LogAreas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "ProcessosUsuario",
                type: "time",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogProcessos",
                type: "time",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogEmpresas",
                type: "time",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoDecorrido",
                table: "LogAreas",
                type: "time",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
