using Microsoft.EntityFrameworkCore.Migrations;

namespace Show4AllV3.Data.Migrations
{
    public partial class TestImge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TvShow",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TvShow");
        }
    }
}
