using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class MoverColunaIdCarroDeParadaParaRota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RotaParadas_Carros_IdCarro",
                table: "RotaParadas");

            migrationBuilder.DropIndex(
                name: "IX_RotaParadas_IdCarro",
                table: "RotaParadas");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "RotaParadas");

            migrationBuilder.AddColumn<long>(
                name: "IdCarro",
                table: "Rotas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 17L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 18L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 19L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 20L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 21L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 22L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 23L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 24L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 25L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "Motoristas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 4, 1, 20, 5, 35, 405, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_IdCarro",
                table: "Rotas",
                column: "IdCarro");

            migrationBuilder.AddForeignKey(
                name: "FK_Rotas_Carros_IdCarro",
                table: "Rotas",
                column: "IdCarro",
                principalTable: "Carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rotas_Carros_IdCarro",
                table: "Rotas");

            migrationBuilder.DropIndex(
                name: "IX_Rotas_IdCarro",
                table: "Rotas");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "Rotas");

            migrationBuilder.AddColumn<long>(
                name: "IdCarro",
                table: "RotaParadas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 17L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 18L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 19L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 20L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 21L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 22L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 23L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 24L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 25L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Motoristas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadas_IdCarro",
                table: "RotaParadas",
                column: "IdCarro");

            migrationBuilder.AddForeignKey(
                name: "FK_RotaParadas_Carros_IdCarro",
                table: "RotaParadas",
                column: "IdCarro",
                principalTable: "Carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
