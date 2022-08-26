using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class newclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Employee_Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Projects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Employee_Projects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_Employee_Projects_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.ProjectId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Users_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Users",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "EmailAddress", "Lastname", "Name", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, "User", "null", "lastname", "name", new byte[] { 76, 13, 158, 199, 83, 244, 123, 15, 120, 190, 48, 90, 18, 125, 117, 73, 175, 206, 104, 190, 21, 173, 30, 18, 168, 239, 234, 134, 47, 86, 254, 146, 211, 68, 234, 197, 182, 237, 213, 173, 36, 25, 150, 89, 225, 211, 143, 190, 238, 74, 0, 69, 102, 135, 99, 197, 173, 163, 190, 114, 133, 220, 17, 14 }, new byte[] { 210, 239, 70, 92, 144, 191, 222, 110, 139, 175, 65, 73, 6, 178, 40, 241, 44, 176, 4, 50, 59, 167, 100, 208, 195, 10, 223, 106, 43, 10, 138, 73, 196, 23, 174, 250, 51, 143, 147, 96, 54, 220, 73, 3, 216, 163, 146, 165, 158, 183, 233, 229, 94, 57, 203, 23, 166, 52, 111, 211, 81, 58, 59, 117, 39, 180, 99, 10, 249, 232, 184, 10, 6, 116, 219, 25, 89, 150, 43, 166, 254, 213, 246, 37, 240, 25, 27, 0, 63, 114, 173, 77, 160, 40, 108, 200, 179, 39, 87, 14, 102, 230, 126, 180, 158, 80, 210, 211, 69, 112, 7, 121, 41, 19, 176, 176, 211, 65, 193, 136, 17, 234, 185, 185, 73, 96, 15, 22 }, "Administrator", "administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_userId",
                table: "Users",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Projects_ProjectId",
                table: "Employee_Projects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_userId",
                table: "Users",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_userId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Employee_Projects");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropIndex(
                name: "IX_Users_userId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_Employees_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 122, 126, 57, 16, 62, 239, 217, 49, 8, 208, 78, 162, 184, 194, 207, 188, 131, 1, 248, 218, 8, 202, 86, 26, 196, 21, 99, 1, 74, 243, 7, 164, 99, 77, 219, 127, 91, 165, 92, 158, 194, 137, 104, 47, 199, 67, 224, 43, 117, 242, 88, 241, 74, 194, 118, 59, 204, 255, 202, 216, 53, 23, 119, 89 }, new byte[] { 111, 90, 2, 196, 162, 44, 250, 177, 184, 172, 104, 184, 89, 242, 200, 46, 220, 135, 49, 34, 125, 46, 80, 104, 55, 194, 147, 102, 229, 192, 51, 10, 184, 199, 225, 236, 225, 247, 158, 41, 223, 85, 243, 219, 246, 247, 229, 243, 185, 200, 126, 122, 142, 44, 223, 17, 69, 229, 237, 218, 111, 233, 2, 117, 85, 180, 242, 149, 127, 65, 140, 230, 45, 39, 21, 246, 251, 78, 154, 98, 43, 58, 50, 189, 115, 77, 231, 206, 220, 58, 69, 251, 210, 43, 166, 100, 186, 49, 65, 153, 96, 97, 37, 99, 125, 60, 143, 120, 193, 101, 206, 92, 198, 189, 109, 183, 47, 41, 99, 4, 122, 84, 185, 28, 233, 5, 105, 76 } });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_userId",
                table: "Employees",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id"
                );
        }
    }
}
