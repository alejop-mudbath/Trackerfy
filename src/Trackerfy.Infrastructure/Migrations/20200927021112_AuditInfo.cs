using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackerfy.Infrastructure.Migrations
{
    public partial class AuditInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Issue",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Issue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Issue");
        }
    }
}
