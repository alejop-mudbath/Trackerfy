using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackerfy.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(nullable: false),
                    IssueTypeId = table.Column<int>(nullable: false),
                    IssueStateId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue_IssueState_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IssueState",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "To Do" },
                    { 2, "In Progress" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "IssueType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Story" },
                    { 2, "Bug" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_IssueStateId",
                table: "Issue",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_IssueTypeId",
                table: "Issue",
                column: "IssueTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "IssueState");

            migrationBuilder.DropTable(
                name: "IssueType");
        }
    }
}
