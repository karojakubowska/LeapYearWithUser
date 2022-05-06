using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeapYearWithUser.Data.Migrations
{
    public partial class editperson_namelastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameLastname",
                table: "Person",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameLastname",
                table: "Person");
        }
    }
}
