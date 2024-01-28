using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perkuliahan.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Kuliahs_Kode_MK",
                table: "Kuliahs",
                column: "Kode_MK");

            migrationBuilder.CreateIndex(
                name: "IX_Kuliahs_Nim",
                table: "Kuliahs",
                column: "Nim");

            migrationBuilder.CreateIndex(
                name: "IX_Kuliahs_Nip",
                table: "Kuliahs",
                column: "Nip",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kuliahs_Dosens_Nip",
                table: "Kuliahs",
                column: "Nip",
                principalTable: "Dosens",
                principalColumn: "Nip",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kuliahs_Mahasiswas_Nim",
                table: "Kuliahs",
                column: "Nim",
                principalTable: "Mahasiswas",
                principalColumn: "Nim",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kuliahs_MataKuliahs_Kode_MK",
                table: "Kuliahs",
                column: "Kode_MK",
                principalTable: "MataKuliahs",
                principalColumn: "Kode_MK",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kuliahs_Dosens_Nip",
                table: "Kuliahs");

            migrationBuilder.DropForeignKey(
                name: "FK_Kuliahs_Mahasiswas_Nim",
                table: "Kuliahs");

            migrationBuilder.DropForeignKey(
                name: "FK_Kuliahs_MataKuliahs_Kode_MK",
                table: "Kuliahs");

            migrationBuilder.DropIndex(
                name: "IX_Kuliahs_Kode_MK",
                table: "Kuliahs");

            migrationBuilder.DropIndex(
                name: "IX_Kuliahs_Nim",
                table: "Kuliahs");

            migrationBuilder.DropIndex(
                name: "IX_Kuliahs_Nip",
                table: "Kuliahs");
        }
    }
}
