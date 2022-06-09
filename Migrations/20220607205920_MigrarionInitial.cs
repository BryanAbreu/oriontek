using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oriontek.Migrations
{
    public partial class MigrarionInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    idclient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.idclient);
                });

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    iddirecc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idcli = table.Column<int>(type: "int", nullable: true),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.iddirecc);
                    table.ForeignKey(
                        name: "FK_direccion_client",
                        column: x => x.idcli,
                        principalTable: "client",
                        principalColumn: "idclient");
                });

            migrationBuilder.CreateIndex(
                name: "IX_direccion_idcli",
                table: "direccion",
                column: "idcli");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
