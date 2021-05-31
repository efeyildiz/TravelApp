using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Migrations
{
    public partial class AddLokantaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokantas",
                columns: table => new
                {
                    LokantaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    lokantaAd = table.Column<string>(nullable: true),
                    lokantaTel = table.Column<string>(nullable: true),
                    lokantaPuan = table.Column<double>(nullable: false),
                    lokantaAdres = table.Column<string>(nullable: true),
                    lokantaAciklama = table.Column<string>(nullable: true),
                    lokantaImage = table.Column<string>(nullable: true),
                    SehirId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokantas", x => x.LokantaId);
                    table.ForeignKey(
                        name: "FK_Lokantas_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokantas_SehirId",
                table: "Lokantas",
                column: "SehirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokantas");
        }
    }
}
