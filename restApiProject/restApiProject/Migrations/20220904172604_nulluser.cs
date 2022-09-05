using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class nulluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 162, 96, 7, 33, 169, 200, 94, 196, 71, 56, 187, 127, 92, 113, 141, 170, 34, 144, 248, 177, 33, 252, 180, 172, 48, 115, 119, 110, 37, 251, 52, 44, 161, 236, 4, 23, 59, 113, 54, 76, 209, 124, 144, 104, 254, 235, 218, 25, 210, 130, 0, 192, 125, 212, 139, 182, 212, 240, 17, 79, 179, 208, 99, 220 }, new byte[] { 148, 142, 130, 218, 239, 136, 191, 75, 111, 166, 213, 192, 159, 116, 25, 146, 16, 89, 63, 55, 242, 58, 166, 58, 252, 45, 31, 127, 223, 228, 155, 255, 87, 85, 11, 192, 27, 200, 95, 177, 7, 131, 138, 228, 121, 193, 71, 187, 163, 37, 217, 58, 147, 21, 143, 66, 121, 125, 66, 181, 205, 201, 190, 39, 241, 150, 142, 246, 32, 23, 176, 137, 24, 249, 0, 189, 43, 111, 83, 127, 177, 98, 236, 80, 24, 224, 4, 75, 165, 50, 74, 140, 217, 195, 194, 155, 191, 153, 186, 255, 97, 159, 28, 41, 27, 232, 95, 74, 250, 191, 144, 150, 233, 142, 250, 104, 125, 19, 95, 68, 127, 239, 6, 198, 195, 157, 168, 70 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 231, 137, 24, 38, 153, 10, 83, 131, 73, 91, 205, 117, 188, 227, 4, 35, 18, 163, 175, 204, 63, 157, 25, 70, 137, 61, 105, 189, 108, 145, 6, 49, 34, 111, 24, 221, 26, 109, 169, 239, 99, 132, 173, 175, 49, 114, 76, 148, 0, 94, 181, 67, 45, 42, 160, 83, 216, 75, 177, 39, 220, 164, 127, 202 }, new byte[] { 3, 12, 95, 74, 84, 160, 119, 27, 233, 49, 143, 19, 116, 71, 248, 146, 81, 251, 206, 122, 16, 112, 205, 235, 126, 244, 37, 49, 54, 194, 64, 136, 108, 48, 28, 145, 126, 113, 121, 67, 101, 14, 18, 80, 173, 181, 231, 38, 2, 150, 130, 144, 125, 63, 185, 66, 7, 186, 36, 31, 222, 232, 228, 171, 6, 226, 215, 9, 131, 242, 138, 94, 65, 200, 104, 141, 121, 213, 72, 124, 126, 8, 1, 247, 243, 9, 73, 137, 144, 135, 201, 156, 131, 219, 65, 141, 154, 246, 201, 34, 60, 180, 215, 44, 50, 81, 16, 209, 75, 152, 117, 128, 217, 66, 183, 119, 65, 2, 137, 4, 77, 47, 154, 190, 183, 32, 133, 229 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
