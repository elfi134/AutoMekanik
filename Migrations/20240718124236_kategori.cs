using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMekanikV3Final.Migrations
{
    /// <inheritdoc />
    public partial class kategori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriaNumri",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "kategori",
                columns: table => new
                {
                    Numri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategori", x => x.Numri);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kategori");

            migrationBuilder.DropColumn(
                name: "KategoriaNumri",
                table: "Cars");
        }
    }
}
