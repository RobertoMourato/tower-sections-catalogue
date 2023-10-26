using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_side.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BottomDiameter = table.Column<double>(type: "REAL", nullable: false),
                    TopDiameter = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shells",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    BottomDiameter = table.Column<double>(type: "REAL", nullable: false),
                    TopDiameter = table.Column<double>(type: "REAL", nullable: false),
                    Thickness = table.Column<double>(type: "REAL", nullable: false),
                    SteelDensity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionShells",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionId = table.Column<long>(type: "INTEGER", nullable: false),
                    ShellId = table.Column<long>(type: "INTEGER", nullable: false),
                    ShellPosition = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionShells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionShells_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionShells_Shells_ShellId",
                        column: x => x.ShellId,
                        principalTable: "Shells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionShells_SectionId",
                table: "SectionShells",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionShells_ShellId",
                table: "SectionShells",
                column: "ShellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionShells");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Shells");
        }
    }
}
