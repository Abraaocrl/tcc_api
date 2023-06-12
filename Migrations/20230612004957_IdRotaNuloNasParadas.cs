using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class IdRotaNuloNasParadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RotaParadas_Rotas_IdRota",
                table: "RotaParadas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rotas_Carros_IdCarro",
                table: "Rotas");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Rotas_IdCarro",
                table: "Rotas");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "Rotas");

            migrationBuilder.AlterColumn<long>(
                name: "IdRota",
                table: "RotaParadas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_RotaParadas_Rotas_IdRota",
                table: "RotaParadas",
                column: "IdRota",
                principalTable: "Rotas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RotaParadas_Rotas_IdRota",
                table: "RotaParadas");

            migrationBuilder.AddColumn<long>(
                name: "IdCarro",
                table: "Rotas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "IdRota",
                table: "RotaParadas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Documento = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motoristas_Users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMotorista = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Passageiros = table.Column<int>(type: "integer", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Motoristas_IdMotorista",
                        column: x => x.IdMotorista,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Motoristas",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "DataNascimento", "Documento", "IdUsuario", "Nome" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1998, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "123.123.123-12", 1L, "Abraão Costa" });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "IdMotorista", "Passageiros", "Placa" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 1L, 10, "HWI8828" });

            migrationBuilder.UpdateData(
                table: "Rotas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IdCarro",
                value: 1L);

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_IdCarro",
                table: "Rotas",
                column: "IdCarro");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_IdMotorista",
                table: "Carros",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_IdUsuario",
                table: "Motoristas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RotaParadas_Rotas_IdRota",
                table: "RotaParadas",
                column: "IdRota",
                principalTable: "Rotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rotas_Carros_IdCarro",
                table: "Rotas",
                column: "IdCarro",
                principalTable: "Carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
