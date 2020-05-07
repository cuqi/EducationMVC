using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationMVC.Migrations
{
    public partial class ProfilePicture_Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Teacher",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Teacher");
        }
    }
}
