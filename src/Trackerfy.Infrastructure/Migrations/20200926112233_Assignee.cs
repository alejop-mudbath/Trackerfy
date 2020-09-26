using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackerfy.Infrastructure.Migrations
{
    public partial class Assignee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Issue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Issue");
        }
    }
}
