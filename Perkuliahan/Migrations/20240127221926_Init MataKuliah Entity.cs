using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perkuliahan.Migrations
{
    /// <inheritdoc />
    public partial class InitMataKuliahEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MataKuliahs",
                columns: table => new
                {
                    Kode_MK = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Nama_MK = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataKuliahs", x => x.Kode_MK);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MataKuliahs");
        }
    }
}
