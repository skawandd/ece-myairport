using Microsoft.EntityFrameworkCore.Migrations;

namespace FLS.MyAirport.EF.Migrations
{
    public partial class BagageVolIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bagages_Vols_VolID",
                table: "Bagages");

            migrationBuilder.DropColumn(
                name: "JEX",
                table: "Vols");

            migrationBuilder.AlterColumn<int>(
                name: "VolID",
                table: "Bagages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bagages_Vols_VolID",
                table: "Bagages",
                column: "VolID",
                principalTable: "Vols",
                principalColumn: "VolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bagages_Vols_VolID",
                table: "Bagages");

            migrationBuilder.AddColumn<short>(
                name: "JEX",
                table: "Vols",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<int>(
                name: "VolID",
                table: "Bagages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bagages_Vols_VolID",
                table: "Bagages",
                column: "VolID",
                principalTable: "Vols",
                principalColumn: "VolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
