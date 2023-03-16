using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRotaParadaOrigem = table.Column<long>(type: "bigint", nullable: true),
                    IdRotaParadaDestino = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Documento = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Passageiros = table.Column<int>(type: "integer", nullable: false),
                    IdMotorista = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "RotaParadas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    IdCidade = table.Column<long>(type: "bigint", nullable: false),
                    IdCarro = table.Column<long>(type: "bigint", nullable: false),
                    IdRota = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaParadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotaParadas_Carros_IdCarro",
                        column: x => x.IdCarro,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaParadas_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaParadas_Rotas_IdRota",
                        column: x => x.IdRota,
                        principalTable: "Rotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaParadaHorarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Horario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdRotaParada = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaParadaHorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotaParadaHorarios_RotaParadas_IdRotaParada",
                        column: x => x.IdRotaParada,
                        principalTable: "RotaParadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaPrecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRota = table.Column<long>(type: "bigint", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    IdRotaParadaOrigem = table.Column<long>(type: "bigint", nullable: true),
                    IdRotaParadaDestino = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotaPrecos_RotaParadas_IdRotaParadaDestino",
                        column: x => x.IdRotaParadaDestino,
                        principalTable: "RotaParadas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RotaPrecos_RotaParadas_IdRotaParadaOrigem",
                        column: x => x.IdRotaParadaOrigem,
                        principalTable: "RotaParadas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RotaPrecos_Rotas_IdRota",
                        column: x => x.IdRota,
                        principalTable: "Rotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "Estado", "Nome" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6135), null, "CE", "Fortaleza" },
                    { 2L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6142), null, "CE", "Aracati" },
                    { 3L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6143), null, "CE", "Aquiraz" },
                    { 4L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6145), null, "CE", "Acaraú" },
                    { 5L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6146), null, "CE", "Viçosa do Ceará" },
                    { 6L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6147), null, "CE", "Antonina do Norte" },
                    { 7L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6148), null, "CE", "Abaiara" },
                    { 8L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6149), null, "CE", "Acarape" },
                    { 9L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6150), null, "CE", "Sobral" },
                    { 10L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6151), null, "CE", "Crato" },
                    { 11L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6152), null, "CE", "Juazeiro do Norte" },
                    { 12L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6153), null, "CE", "Itapipoca" },
                    { 13L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6154), null, "CE", "Canindé" },
                    { 14L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6155), null, "CE", "Massapê" },
                    { 15L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6156), null, "CE", "Martinópole" },
                    { 16L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6157), null, "CE", "Granja" },
                    { 17L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6158), null, "CE", "Uruoca" },
                    { 18L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6158), null, "CE", "Senador Sá" },
                    { 19L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6159), null, "CE", "Tianguá" },
                    { 20L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6160), null, "CE", "Frecheirinha" },
                    { 21L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6161), null, "CE", "São Benedito" },
                    { 22L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6162), null, "CE", "Jijoca" },
                    { 23L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6163), null, "CE", "Cruz" },
                    { 24L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6164), null, "CE", "Meruoca" },
                    { 25L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6165), null, "CE", "Camocim" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "Email", "Senha", "Username" },
                values: new object[] { 1L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6272), null, "abraaocrl@email.com.br", "827CCB0EEA8A706C4C34A16891F84E7B", "abraaocrl" });

            migrationBuilder.InsertData(
                table: "Motoristas",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "DataNascimento", "Documento", "IdUsuario", "Nome" },
                values: new object[] { 1L, new DateTime(2023, 3, 16, 11, 29, 30, 470, DateTimeKind.Utc).AddTicks(6284), null, new DateTime(1998, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "123.123.123-12", 1L, "Abraão Costa" });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "DataCriacao", "DataEdicao", "IdMotorista", "Passageiros", "Placa" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, 1L, 10, "HWI8828" });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_IdMotorista",
                table: "Carros",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_IdUsuario",
                table: "Motoristas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadaHorarios_IdRotaParada",
                table: "RotaParadaHorarios",
                column: "IdRotaParada");

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadas_IdCarro",
                table: "RotaParadas",
                column: "IdCarro");

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadas_IdCidade",
                table: "RotaParadas",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadas_IdRota",
                table: "RotaParadas",
                column: "IdRota");

            migrationBuilder.CreateIndex(
                name: "IX_RotaPrecos_IdRota",
                table: "RotaPrecos",
                column: "IdRota");

            migrationBuilder.CreateIndex(
                name: "IX_RotaPrecos_IdRotaParadaDestino",
                table: "RotaPrecos",
                column: "IdRotaParadaDestino");

            migrationBuilder.CreateIndex(
                name: "IX_RotaPrecos_IdRotaParadaOrigem",
                table: "RotaPrecos",
                column: "IdRotaParadaOrigem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotaParadaHorarios");

            migrationBuilder.DropTable(
                name: "RotaPrecos");

            migrationBuilder.DropTable(
                name: "RotaParadas");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
