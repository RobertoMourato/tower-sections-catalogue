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
                name: "sections",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    part_number = table.Column<string>(type: "TEXT", nullable: true),
                    bottom_diameter = table.Column<double>(type: "REAL", nullable: true),
                    top_diameter = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shells",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    height = table.Column<double>(type: "REAL", nullable: true),
                    bottom_diameter = table.Column<double>(type: "REAL", nullable: true),
                    top_diameter = table.Column<double>(type: "REAL", nullable: true),
                    thickness = table.Column<double>(type: "REAL", nullable: true),
                    steel_density = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shells", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "section_shell",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    section_id = table.Column<long>(type: "INTEGER", nullable: true),
                    shell_id = table.Column<long>(type: "INTEGER", nullable: true),
                    shell_position = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_shell", x => x.id);
                    table.ForeignKey(
                        name: "FK_section_shell_sections_section_id",
                        column: x => x.section_id,
                        principalTable: "sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_section_shell_shells_shell_id",
                        column: x => x.shell_id,
                        principalTable: "shells",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_section_shell_section_id",
                table: "section_shell",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_section_shell_shell_id",
                table: "section_shell",
                column: "shell_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "section_shell");

            migrationBuilder.DropTable(
                name: "sections");

            migrationBuilder.DropTable(
                name: "shells");
        }
    }
}
