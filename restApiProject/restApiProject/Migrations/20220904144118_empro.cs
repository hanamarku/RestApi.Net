﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApiProject.Migrations
{
    public partial class empro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 255, 88, 97, 244, 177, 115, 51, 251, 52, 236, 7, 14, 9, 113, 126, 57, 105, 255, 24, 145, 130, 105, 6, 231, 60, 213, 75, 177, 231, 138, 23, 104, 57, 137, 245, 0, 191, 235, 196, 32, 179, 19, 56, 129, 58, 122, 2, 205, 180, 183, 212, 135, 169, 95, 156, 222, 232, 194, 112, 21, 184, 226, 99, 172 }, new byte[] { 176, 207, 115, 109, 30, 224, 82, 251, 201, 69, 220, 105, 189, 241, 219, 131, 70, 155, 134, 209, 249, 50, 136, 185, 100, 92, 162, 176, 21, 217, 119, 144, 17, 239, 88, 86, 22, 35, 95, 219, 12, 36, 237, 1, 172, 66, 142, 33, 244, 22, 5, 0, 114, 40, 18, 83, 201, 204, 55, 64, 209, 200, 105, 75, 99, 220, 56, 241, 231, 130, 10, 98, 168, 40, 217, 238, 18, 197, 138, 171, 68, 29, 15, 9, 143, 68, 226, 34, 30, 204, 218, 87, 2, 27, 74, 61, 165, 62, 152, 35, 104, 16, 95, 246, 34, 90, 42, 136, 189, 165, 247, 73, 148, 155, 55, 236, 82, 5, 200, 238, 203, 93, 233, 115, 207, 144, 169, 31 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 247, 42, 212, 100, 205, 92, 148, 146, 151, 158, 128, 226, 148, 6, 34, 163, 212, 119, 139, 249, 35, 96, 28, 156, 108, 99, 90, 14, 169, 54, 209, 180, 148, 122, 131, 81, 128, 43, 57, 255, 67, 99, 195, 91, 201, 135, 223, 195, 168, 30, 79, 17, 229, 186, 74, 253, 35, 27, 122, 95, 173, 135, 81, 242 }, new byte[] { 88, 34, 188, 194, 124, 53, 255, 172, 9, 176, 62, 200, 32, 136, 172, 64, 35, 62, 166, 214, 172, 170, 133, 220, 249, 137, 221, 40, 178, 86, 208, 97, 153, 77, 213, 23, 243, 0, 147, 164, 255, 154, 210, 155, 121, 121, 224, 194, 213, 136, 139, 14, 65, 38, 27, 233, 158, 43, 152, 179, 149, 172, 233, 36, 244, 11, 156, 112, 137, 16, 254, 155, 251, 113, 252, 195, 49, 214, 244, 104, 146, 41, 129, 188, 78, 193, 41, 105, 120, 224, 253, 241, 72, 62, 45, 210, 166, 136, 202, 162, 104, 244, 12, 254, 13, 126, 76, 105, 31, 229, 2, 224, 63, 100, 107, 170, 27, 156, 103, 101, 170, 124, 216, 185, 176, 81, 178, 193 } });
        }
    }
}
