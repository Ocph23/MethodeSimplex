using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kriteria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NamaKriteria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kriteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NamaVariable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aturans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NamaAturan = table.Column<string>(nullable: true),
                    KriteriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aturans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aturans_Kriteria_KriteriaId",
                        column: x => x.KriteriaId,
                        principalTable: "Kriteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JenisKayu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(nullable: true),
                    KriteriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKayu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JenisKayu_Kriteria_KriteriaId",
                        column: x => x.KriteriaId,
                        principalTable: "Kriteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hasils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Hasil = table.Column<double>(nullable: false),
                    VariableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hasils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hasils_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aturans_KriteriaId",
                table: "Aturans",
                column: "KriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hasils_VariableId",
                table: "Hasils",
                column: "VariableId");

            migrationBuilder.CreateIndex(
                name: "IX_JenisKayu_KriteriaId",
                table: "JenisKayu",
                column: "KriteriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aturans");

            migrationBuilder.DropTable(
                name: "Hasils");

            migrationBuilder.DropTable(
                name: "JenisKayu");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "Kriteria");
        }
    }
}
