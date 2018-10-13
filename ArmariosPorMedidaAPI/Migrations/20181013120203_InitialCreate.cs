using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArmariosPorMedidaAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acabamentos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acabamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CategoriaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categorias_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partes",
                columns: table => new
                {
                    ParteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Altura = table.Column<double>(nullable: false),
                    Largura = table.Column<double>(nullable: false),
                    Profundidade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partes", x => x.ParteID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Altura = table.Column<double>(nullable: false),
                    Largura = table.Column<double>(nullable: false),
                    Profundidade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                });

            migrationBuilder.CreateTable(
                name: "Restricoes",
                columns: table => new
                {
                    RestricaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restricoes", x => x.RestricaoID);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcabamentoID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materiais_Acabamentos_AcabamentoID",
                        column: x => x.AcabamentoID,
                        principalTable: "Acabamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPartes",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false),
                    ParteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPartes", x => new { x.ProdutoID, x.ParteID });
                    table.ForeignKey(
                        name: "FK_ProdutoPartes_Partes_ParteID",
                        column: x => x.ParteID,
                        principalTable: "Partes",
                        principalColumn: "ParteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoPartes_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoRestricoes",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false),
                    RestricaoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoRestricoes", x => new { x.ProdutoID, x.RestricaoID });
                    table.ForeignKey(
                        name: "FK_ProdutoRestricoes_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoRestricoes_Restricoes_RestricaoID",
                        column: x => x.RestricaoID,
                        principalTable: "Restricoes",
                        principalColumn: "RestricaoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaID",
                table: "Categorias",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_AcabamentoID",
                table: "Materiais",
                column: "AcabamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPartes_ParteID",
                table: "ProdutoPartes",
                column: "ParteID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoRestricoes_RestricaoID",
                table: "ProdutoRestricoes",
                column: "RestricaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "ProdutoPartes");

            migrationBuilder.DropTable(
                name: "ProdutoRestricoes");

            migrationBuilder.DropTable(
                name: "Acabamentos");

            migrationBuilder.DropTable(
                name: "Partes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Restricoes");
        }
    }
}
