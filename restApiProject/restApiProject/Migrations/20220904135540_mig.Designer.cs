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
    [Migration("20220904135540_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassLibraryModels.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ClassLibraryModels.ProjectUser", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Employee_Projects");
                });

            modelBuilder.Entity("ClassLibraryModels.Taskk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .IsRequired()
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
                            PasswordHash = new byte[] { 247, 42, 212, 100, 205, 92, 148, 146, 151, 158, 128, 226, 148, 6, 34, 163, 212, 119, 139, 249, 35, 96, 28, 156, 108, 99, 90, 14, 169, 54, 209, 180, 148, 122, 131, 81, 128, 43, 57, 255, 67, 99, 195, 91, 201, 135, 223, 195, 168, 30, 79, 17, 229, 186, 74, 253, 35, 27, 122, 95, 173, 135, 81, 242 },
                            PasswordSalt = new byte[] { 88, 34, 188, 194, 124, 53, 255, 172, 9, 176, 62, 200, 32, 136, 172, 64, 35, 62, 166, 214, 172, 170, 133, 220, 249, 137, 221, 40, 178, 86, 208, 97, 153, 77, 213, 23, 243, 0, 147, 164, 255, 154, 210, 155, 121, 121, 224, 194, 213, 136, 139, 14, 65, 38, 27, 233, 158, 43, 152, 179, 149, 172, 233, 36, 244, 11, 156, 112, 137, 16, 254, 155, 251, 113, 252, 195, 49, 214, 244, 104, 146, 41, 129, 188, 78, 193, 41, 105, 120, 224, 253, 241, 72, 62, 45, 210, 166, 136, 202, 162, 104, 244, 12, 254, 13, 126, 76, 105, 31, 229, 2, 224, 63, 100, 107, 170, 27, 156, 103, 101, 170, 124, 216, 185, 176, 81, 178, 193 },
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

            modelBuilder.Entity("ClassLibraryModels.ProjectUser", b =>
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
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
