using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perkuliahan.Migrations
{
    /// <inheritdoc />
    public partial class InitDosenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosens",
                columns: table => new
                {
                    Nip = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Nama_Dosen = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosens", x => x.Nip);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dosens");
        }
    }
}
