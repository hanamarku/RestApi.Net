﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using restApiProject.Data;

#nullable disable

namespace restApiProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220906110646_porjectid")]
    partial class porjectid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassLibraryModels.Employee_Project", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Employee_Projects");
                });

            modelBuilder.Entity("ClassLibraryModels.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ClassLibraryModels.Taskk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Projectid")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Projectid");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ClassLibraryModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            EmailAddress = "null",
                            ImageUrl = "",
                            Lastname = "lastname",
                            Name = "name",
                            PasswordHash = new byte[] { 35, 35, 91, 73, 226, 203, 120, 9, 114, 147, 207, 255, 83, 147, 95, 40, 245, 170, 221, 118, 169, 137, 5, 224, 36, 34, 249, 100, 223, 247, 237, 122, 32, 239, 218, 154, 211, 33, 126, 85, 95, 194, 19, 193, 7, 238, 23, 241, 233, 89, 84, 194, 115, 157, 217, 20, 235, 80, 216, 142, 26, 22, 14, 45 },
                            PasswordSalt = new byte[] { 91, 37, 211, 182, 242, 152, 98, 38, 230, 179, 34, 164, 119, 46, 225, 50, 166, 164, 186, 20, 60, 1, 225, 143, 80, 248, 13, 204, 186, 38, 199, 237, 42, 71, 60, 17, 182, 167, 175, 14, 171, 95, 245, 142, 166, 183, 36, 152, 27, 85, 55, 182, 6, 235, 232, 171, 26, 119, 107, 122, 75, 244, 39, 233, 159, 54, 154, 215, 26, 122, 104, 23, 5, 204, 105, 220, 168, 246, 226, 44, 11, 9, 47, 51, 130, 255, 159, 51, 213, 16, 42, 3, 196, 65, 189, 147, 152, 47, 93, 249, 175, 255, 224, 158, 51, 174, 123, 222, 90, 116, 243, 36, 148, 161, 16, 116, 236, 196, 224, 32, 75, 152, 70, 106, 255, 220, 156, 231 },
                            Role = "Administrator",
                            Username = "administrator"
                        });
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("ClassLibraryModels.Employee_Project", b =>
                {
                    b.HasOne("ClassLibraryModels.User", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibraryModels.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ClassLibraryModels.Taskk", b =>
                {
                    b.HasOne("ClassLibraryModels.User", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ClassLibraryModels.Project", "project")
                        .WithMany("Tasks")
                        .HasForeignKey("Projectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("ClassLibraryModels.User", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibraryModels.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassLibraryModels.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ClassLibraryModels.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
