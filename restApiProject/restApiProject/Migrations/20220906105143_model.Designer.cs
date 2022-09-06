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
    [Migration("20220906105143_model")]
    partial class model
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

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

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
                            PasswordHash = new byte[] { 221, 142, 133, 238, 236, 215, 181, 72, 179, 152, 148, 231, 234, 63, 159, 66, 128, 118, 138, 60, 254, 135, 169, 223, 152, 62, 211, 217, 120, 55, 178, 72, 14, 242, 246, 79, 15, 143, 137, 54, 197, 25, 200, 50, 205, 255, 90, 59, 7, 23, 36, 149, 215, 13, 168, 6, 58, 229, 37, 75, 93, 12, 99, 85 },
                            PasswordSalt = new byte[] { 254, 2, 100, 187, 144, 144, 141, 100, 79, 63, 178, 202, 16, 46, 100, 52, 42, 145, 51, 178, 110, 21, 242, 84, 160, 122, 189, 98, 93, 32, 70, 231, 48, 143, 148, 114, 103, 54, 123, 244, 63, 53, 68, 23, 248, 50, 71, 93, 202, 98, 121, 98, 151, 1, 12, 128, 222, 131, 119, 163, 108, 21, 107, 249, 147, 213, 117, 15, 67, 83, 143, 215, 215, 9, 248, 141, 153, 221, 5, 223, 184, 122, 138, 57, 255, 21, 27, 229, 52, 30, 123, 101, 173, 227, 239, 88, 103, 242, 229, 46, 100, 212, 29, 41, 140, 250, 246, 179, 184, 63, 207, 48, 151, 89, 46, 162, 47, 113, 103, 13, 126, 54, 189, 167, 195, 168, 249, 125 },
                            ProjectId = 0,
                            Role = "Administrator",
                            Username = "administrator"
                        });
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
