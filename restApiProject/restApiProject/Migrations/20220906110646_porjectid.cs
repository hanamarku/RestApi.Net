using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class porjectid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 35, 35, 91, 73, 226, 203, 120, 9, 114, 147, 207, 255, 83, 147, 95, 40, 245, 170, 221, 118, 169, 137, 5, 224, 36, 34, 249, 100, 223, 247, 237, 122, 32, 239, 218, 154, 211, 33, 126, 85, 95, 194, 19, 193, 7, 238, 23, 241, 233, 89, 84, 194, 115, 157, 217, 20, 235, 80, 216, 142, 26, 22, 14, 45 }, new byte[] { 91, 37, 211, 182, 242, 152, 98, 38, 230, 179, 34, 164, 119, 46, 225, 50, 166, 164, 186, 20, 60, 1, 225, 143, 80, 248, 13, 204, 186, 38, 199, 237, 42, 71, 60, 17, 182, 167, 175, 14, 171, 95, 245, 142, 166, 183, 36, 152, 27, 85, 55, 182, 6, 235, 232, 171, 26, 119, 107, 122, 75, 244, 39, 233, 159, 54, 154, 215, 26, 122, 104, 23, 5, 204, 105, 220, 168, 246, 226, 44, 11, 9, 47, 51, 130, 255, 159, 51, 213, 16, 42, 3, 196, 65, 189, 147, 152, 47, 93, 249, 175, 255, 224, 158, 51, 174, 123, 222, 90, 116, 243, 36, 148, 161, 16, 116, 236, 196, 224, 32, 75, 152, 70, 106, 255, 220, 156, 231 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectsId",
                table: "ProjectUser",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 77, 150, 252, 253, 20, 173, 202, 196, 153, 211, 111, 164, 102, 190, 69, 133, 1, 21, 188, 242, 229, 164, 247, 138, 237, 17, 155, 218, 240, 82, 175, 15, 67, 151, 227, 93, 149, 248, 37, 58, 228, 48, 7, 54, 181, 59, 246, 62, 249, 159, 12, 6, 11, 51, 225, 16, 81, 198, 36, 253, 97, 247, 195 }, new byte[] { 195, 168, 173, 53, 219, 147, 213, 137, 243, 115, 205, 8, 243, 46, 168, 104, 157, 97, 66, 78, 156, 202, 78, 218, 43, 5, 143, 166, 4, 35, 43, 148, 249, 95, 178, 223, 100, 165, 53, 122, 75, 147, 119, 168, 226, 38, 236, 255, 48, 218, 11, 239, 140, 137, 94, 248, 103, 99, 25, 81, 100, 217, 23, 92, 199, 42, 139, 166, 119, 172, 95, 100, 82, 84, 142, 172, 185, 221, 40, 54, 235, 190, 84, 21, 252, 219, 188, 41, 205, 97, 81, 186, 28, 108, 252, 228, 214, 95, 197, 220, 35, 142, 166, 220, 67, 55, 155, 51, 243, 166, 64, 39, 235, 82, 22, 172, 201, 194, 145, 150, 222, 180, 116, 223, 144, 3, 12, 213 } });
        }
    }
}
