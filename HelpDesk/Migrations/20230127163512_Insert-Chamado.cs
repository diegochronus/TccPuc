using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDesk.Migrations
{
    public partial class InsertChamado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    IdChamado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NmOperador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoChamado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentroCusto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoChamado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoriaServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NmNivelOperacional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.IdChamado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");
        }
    }
}
