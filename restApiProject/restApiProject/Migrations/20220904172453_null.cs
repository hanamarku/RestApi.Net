using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class @null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Tasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Projects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 231, 137, 24, 38, 153, 10, 83, 131, 73, 91, 205, 117, 188, 227, 4, 35, 18, 163, 175, 204, 63, 157, 25, 70, 137, 61, 105, 189, 108, 145, 6, 49, 34, 111, 24, 221, 26, 109, 169, 239, 99, 132, 173, 175, 49, 114, 76, 148, 0, 94, 181, 67, 45, 42, 160, 83, 216, 75, 177, 39, 220, 164, 127, 202 }, new byte[] { 3, 12, 95, 74, 84, 160, 119, 27, 233, 49, 143, 19, 116, 71, 248, 146, 81, 251, 206, 122, 16, 112, 205, 235, 126, 244, 37, 49, 54, 194, 64, 136, 108, 48, 28, 145, 126, 113, 121, 67, 101, 14, 18, 80, 173, 181, 231, 38, 2, 150, 130, 144, 125, 63, 185, 66, 7, 186, 36, 31, 222, 232, 228, 171, 6, 226, 215, 9, 131, 242, 138, 94, 65, 200, 104, 141, 121, 213, 72, 124, 126, 8, 1, 247, 243, 9, 73, 137, 144, 135, 201, 156, 131, 219, 65, 141, 154, 246, 201, 34, 60, 180, 215, 44, 50, 81, 16, 209, 75, 152, 117, 128, 217, 66, 183, 119, 65, 2, 137, 4, 77, 47, 154, 190, 183, 32, 133, 229 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 255, 88, 97, 244, 177, 115, 51, 251, 52, 236, 7, 14, 9, 113, 126, 57, 105, 255, 24, 145, 130, 105, 6, 231, 60, 213, 75, 177, 231, 138, 23, 104, 57, 137, 245, 0, 191, 235, 196, 32, 179, 19, 56, 129, 58, 122, 2, 205, 180, 183, 212, 135, 169, 95, 156, 222, 232, 194, 112, 21, 184, 226, 99, 172 }, new byte[] { 176, 207, 115, 109, 30, 224, 82, 251, 201, 69, 220, 105, 189, 241, 219, 131, 70, 155, 134, 209, 249, 50, 136, 185, 100, 92, 162, 176, 21, 217, 119, 144, 17, 239, 88, 86, 22, 35, 95, 219, 12, 36, 237, 1, 172, 66, 142, 33, 244, 22, 5, 0, 114, 40, 18, 83, 201, 204, 55, 64, 209, 200, 105, 75, 99, 220, 56, 241, 231, 130, 10, 98, 168, 40, 217, 238, 18, 197, 138, 171, 68, 29, 15, 9, 143, 68, 226, 34, 30, 204, 218, 87, 2, 27, 74, 61, 165, 62, 152, 35, 104, 16, 95, 246, 34, 90, 42, 136, 189, 165, 247, 73, 148, 155, 55, 236, 82, 5, 200, 238, 203, 93, 233, 115, 207, 144, 169, 31 } });
        }
    }
}
