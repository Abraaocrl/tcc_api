using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class SeedRotaParadaHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rotas",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "IdCarro", "IdRotaParadaDestino", "IdRotaParadaOrigem" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 1L, null, null });

            migrationBuilder.InsertData(
                table: "RotaParadas",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "IdCidade", "IdRota", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 9L, 1L, 0.0, 0.0 },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 14L, 1L, 0.0, 0.0 },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 18L, 1L, 0.0, 0.0 },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 17L, 1L, 0.0, 0.0 },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 15L, 1L, 0.0, 0.0 },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 16L, 1L, 0.0, 0.0 },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 25L, 1L, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "RotaParadaHorarios",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "Horario", "IdRotaParada" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 1L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc), 1L },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 5, 30, 0, 0, DateTimeKind.Utc), 2L },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Utc), 2L },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), 3L },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), 3L },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Utc), 4L },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 9, 30, 0, 0, DateTimeKind.Utc), 4L },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Utc), 5L },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), 5L },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Utc), 6L },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Utc), 6L },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), 7L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "RotaParadaHorarios",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "RotaParadas",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Rotas",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
