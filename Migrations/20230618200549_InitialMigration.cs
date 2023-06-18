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
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Sobrenome = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    IdRota = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaParadas", x => x.Id);
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
                        principalColumn: "Id");
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
                    Distancia = table.Column<double>(type: "double precision", nullable: false),
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
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Fortaleza" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Aracati" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Aquiraz" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Acaraú" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Viçosa do Ceará" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Antonina do Norte" },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Abaiara" },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Acarape" },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Sobral" },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Crato" },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Juazeiro do Norte" },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Itapipoca" },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Canindé" },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Massapê" },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Martinópole" },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Granja" },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Uruoca" },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Senador Sá" },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Tianguá" },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Frecheirinha" },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "São Benedito" },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Jijoca" },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Cruz" },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Meruoca" },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "CE", "Camocim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotaParadaHorarios_IdRotaParada",
                table: "RotaParadaHorarios",
                column: "IdRotaParada");

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "RotaParadas");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Rotas");
        }
    }
}
