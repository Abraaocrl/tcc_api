using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class AddColunasNomeSobrenomeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "DataCriacao", "Nome", "Sobrenome" },
                values: new object[] { new DateTime(2023, 3, 20, 18, 14, 56, 769, DateTimeKind.Utc).AddTicks(9337), "Abraão", "Costa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 17L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 18L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 19L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 20L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 21L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 22L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 23L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 24L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 25L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Motoristas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 16, 11, 30, 28, 724, DateTimeKind.Utc).AddTicks(6851));
        }
    }
}
