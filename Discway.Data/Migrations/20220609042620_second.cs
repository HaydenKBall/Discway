using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discway.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_TagId",
                table: "User",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tag_TagId",
                table: "User",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tag_TagId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TagId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "User");
        }
    }
}
