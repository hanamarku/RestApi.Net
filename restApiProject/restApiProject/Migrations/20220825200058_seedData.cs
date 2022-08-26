using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Lastname", "Name", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, "null", "lastname", "name", new byte[] { 122, 126, 57, 16, 62, 239, 217, 49, 8, 208, 78, 162, 184, 194, 207, 188, 131, 1, 248, 218, 8, 202, 86, 26, 196, 21, 99, 1, 74, 243, 7, 164, 99, 77, 219, 127, 91, 165, 92, 158, 194, 137, 104, 47, 199, 67, 224, 43, 117, 242, 88, 241, 74, 194, 118, 59, 204, 255, 202, 216, 53, 23, 119, 89 }, new byte[] { 111, 90, 2, 196, 162, 44, 250, 177, 184, 172, 104, 184, 89, 242, 200, 46, 220, 135, 49, 34, 125, 46, 80, 104, 55, 194, 147, 102, 229, 192, 51, 10, 184, 199, 225, 236, 225, 247, 158, 41, 223, 85, 243, 219, 246, 247, 229, 243, 185, 200, 126, 122, 142, 44, 223, 17, 69, 229, 237, 218, 111, 233, 2, 117, 85, 180, 242, 149, 127, 65, 140, 230, 45, 39, 21, 246, 251, 78, 154, 98, 43, 58, 50, 189, 115, 77, 231, 206, 220, 58, 69, 251, 210, 43, 166, 100, 186, 49, 65, 153, 96, 97, 37, 99, 125, 60, 143, 120, 193, 101, 206, 92, 198, 189, 109, 183, 47, 41, 99, 4, 122, 84, 185, 28, 233, 5, 105, 76 }, "Administrator", "administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
