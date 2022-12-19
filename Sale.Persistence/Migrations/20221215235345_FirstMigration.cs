using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sale.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatCriacao = table.Column<DateTime>(name: "Dat_Criacao", type: "datetime2", nullable: false),
                    DatAlteracao = table.Column<DateTime>(name: "Dat_Alteracao", type: "datetime2", nullable: true),
                    DatExclusao = table.Column<DateTime>(name: "Dat_Exclusao", type: "datetime2", nullable: true),
                    CriadoPorUsuId = table.Column<int>(name: "Criado_Por_Usu_Id", type: "int", nullable: false),
                    AlteradoPorUsuId = table.Column<int>(name: "Alterado_Por_Usu_Id", type: "int", nullable: true),
                    ExcluidoPorUsuId = table.Column<int>(name: "Excluido_Por_Usu_Id", type: "int", nullable: true),
                    IndAtivo = table.Column<bool>(name: "Ind_Ativo", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatNascimento = table.Column<DateTime>(name: "Dat_Nascimento", type: "datetime2", nullable: false),
                    DatCriacao = table.Column<DateTime>(name: "Dat_Criacao", type: "datetime2", nullable: false),
                    DatAlteracao = table.Column<DateTime>(name: "Dat_Alteracao", type: "datetime2", nullable: true),
                    DatExclusao = table.Column<DateTime>(name: "Dat_Exclusao", type: "datetime2", nullable: true),
                    CriadoPorUsuId = table.Column<int>(name: "Criado_Por_Usu_Id", type: "int", nullable: false),
                    AlteradoPorUsuId = table.Column<int>(name: "Alterado_Por_Usu_Id", type: "int", nullable: true),
                    ExcluidoPorUsuId = table.Column<int>(name: "Excluido_Por_Usu_Id", type: "int", nullable: true),
                    IndAtivo = table.Column<bool>(name: "Ind_Ativo", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatCriacao = table.Column<DateTime>(name: "Dat_Criacao", type: "datetime2", nullable: false),
                    DatAlteracao = table.Column<DateTime>(name: "Dat_Alteracao", type: "datetime2", nullable: true),
                    DatExclusao = table.Column<DateTime>(name: "Dat_Exclusao", type: "datetime2", nullable: true),
                    CriadoPorUsuId = table.Column<int>(name: "Criado_Por_Usu_Id", type: "int", nullable: false),
                    AlteradoPorUsuId = table.Column<int>(name: "Alterado_Por_Usu_Id", type: "int", nullable: true),
                    ExcluidoPorUsuId = table.Column<int>(name: "Excluido_Por_Usu_Id", type: "int", nullable: true),
                    IndAtivo = table.Column<bool>(name: "Ind_Ativo", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESTOQUE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    NmQuantidade = table.Column<int>(name: "Nm_Quantidade", type: "int", nullable: false),
                    IndAtivo = table.Column<bool>(name: "Ind_Ativo", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTOQUE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS_PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorFinal = table.Column<decimal>(name: "Valor_Final", type: "decimal(18,2)", nullable: false),
                    DatCriacao = table.Column<DateTime>(name: "Dat_Criacao", type: "datetime2", nullable: false),
                    DatAlteracao = table.Column<DateTime>(name: "Dat_Alteracao", type: "datetime2", nullable: true),
                    DatExclusao = table.Column<DateTime>(name: "Dat_Exclusao", type: "datetime2", nullable: true),
                    CriadoPorUsuId = table.Column<int>(name: "Criado_Por_Usu_Id", type: "int", nullable: false),
                    AlteradoPorUsuId = table.Column<int>(name: "Alterado_Por_Usu_Id", type: "int", nullable: true),
                    ExcluidoPorUsuId = table.Column<int>(name: "Excluido_Por_Usu_Id", type: "int", nullable: true),
                    IndAtivo = table.Column<bool>(name: "Ind_Ativo", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VENDAS_PRODUTOS_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENDAS_PRODUTOS_VENDAS_VendaId",
                        column: x => x.VendaId,
                        principalTable: "VENDAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_ProdutoId",
                table: "ESTOQUE",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_PRODUTOS_ProdutoId",
                table: "VENDAS_PRODUTOS",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_PRODUTOS_VendaId",
                table: "VENDAS_PRODUTOS",
                column: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESTOQUE");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "VENDAS_PRODUTOS");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "VENDAS");
        }
    }
}
