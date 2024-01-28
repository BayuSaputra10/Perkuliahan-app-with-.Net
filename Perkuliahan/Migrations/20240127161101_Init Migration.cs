using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perkuliahan.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mahasiswas",
                columns: table => new
                {
                    Nim = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Nama_Mhs = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tgl_lahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jenis_Kelamin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswas", x => x.Nim);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mahasiswas");
        }
    }
}
