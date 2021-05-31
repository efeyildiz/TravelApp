using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Migrations
{
    public partial class AddOtelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    SehirId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plaka = table.Column<int>(nullable: false),
                    sehirAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.SehirId);
                });

            migrationBuilder.CreateTable(
                name: "Otels",
                columns: table => new
                {
                    OtelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    otelAd = table.Column<string>(nullable: true),
                    otelTel = table.Column<string>(nullable: true),
                    otelAdres = table.Column<string>(nullable: true),
                    otelImage = table.Column<string>(nullable: true),
                    otelAciklama = table.Column<string>(nullable: true),
                    otelPuan = table.Column<double>(nullable: false),
                    SehirId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otels", x => x.OtelId);
                    table.ForeignKey(
                        name: "FK_Otels_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Otels_SehirId",
                table: "Otels",
                column: "SehirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otels");

            migrationBuilder.DropTable(
                name: "Sehirs");
        }
    }
}
