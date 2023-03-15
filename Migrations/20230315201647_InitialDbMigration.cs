using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TCC_API.Migrations
{
    public partial class InitialDbMigration : Migration
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
