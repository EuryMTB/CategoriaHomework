using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UT2024P4LP4.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoryId",
                table: "Productos",
                column: "CategoryId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoryId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Productos");
        }
    }
}
