using Microsoft.EntityFrameworkCore.Migrations;

namespace MyClinicPlusV3.Migrations
{
    public partial class ModificacionTablaVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_AspNetUsers_UserId",
                table: "Ventas");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_AspNetUsers_UserId",
                table: "Ventas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_AspNetUsers_UserId",
                table: "Ventas");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_AspNetUsers_UserId",
                table: "Ventas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
