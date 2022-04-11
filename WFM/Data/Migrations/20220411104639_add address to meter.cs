using Microsoft.EntityFrameworkCore.Migrations;

namespace WFM.Data.Migrations
{
    public partial class addaddresstometer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tech");

            migrationBuilder.AddColumn<int>(
                name: "AddressRefId",
                table: "Meter",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressRefId",
                table: "Meter");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tech",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
