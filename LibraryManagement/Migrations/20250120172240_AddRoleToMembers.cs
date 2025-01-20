using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class AddRoleToMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Members",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BorrowingRecords",
                keyColumn: "BorrowingRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2025, 1, 20, 22, 22, 40, 1, DateTimeKind.Local).AddTicks(4112));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "BorrowingRecords",
                keyColumn: "BorrowingRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2025, 1, 20, 21, 57, 38, 148, DateTimeKind.Local).AddTicks(4693));
        }
    }
}
