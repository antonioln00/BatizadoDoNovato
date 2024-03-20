using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatizadoDoNovato.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MinhaPrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Usuario = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Markup = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    PrecoVenda = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    MargemReal = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "RegrasImposto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Taxa = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasImposto", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoRegraImposto",
                columns: table => new
                {
                    ProdutoCodigo = table.Column<int>(type: "int", nullable: false),
                    RegraImpostoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoRegraImposto", x => new { x.ProdutoCodigo, x.RegraImpostoCodigo });
                    table.ForeignKey(
                        name: "FK_ProdutoRegraImposto_Produtos_ProdutoCodigo",
                        column: x => x.ProdutoCodigo,
                        principalTable: "Produtos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoRegraImposto_RegrasImposto_RegraImpostoCodigo",
                        column: x => x.RegraImpostoCodigo,
                        principalTable: "RegrasImposto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoRegraImposto_RegraImpostoCodigo",
                table: "ProdutoRegraImposto",
                column: "RegraImpostoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "ProdutoRegraImposto");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "RegrasImposto");
        }
    }
}
