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
    [Migration("20220904144118_empro")]
    partial class empro
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

                    b.Property<DateTime>("DateUpdated")
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
                            PasswordHash = new byte[] { 255, 88, 97, 244, 177, 115, 51, 251, 52, 236, 7, 14, 9, 113, 126, 57, 105, 255, 24, 145, 130, 105, 6, 231, 60, 213, 75, 177, 231, 138, 23, 104, 57, 137, 245, 0, 191, 235, 196, 32, 179, 19, 56, 129, 58, 122, 2, 205, 180, 183, 212, 135, 169, 95, 156, 222, 232, 194, 112, 21, 184, 226, 99, 172 },
                            PasswordSalt = new byte[] { 176, 207, 115, 109, 30, 224, 82, 251, 201, 69, 220, 105, 189, 241, 219, 131, 70, 155, 134, 209, 249, 50, 136, 185, 100, 92, 162, 176, 21, 217, 119, 144, 17, 239, 88, 86, 22, 35, 95, 219, 12, 36, 237, 1, 172, 66, 142, 33, 244, 22, 5, 0, 114, 40, 18, 83, 201, 204, 55, 64, 209, 200, 105, 75, 99, 220, 56, 241, 231, 130, 10, 98, 168, 40, 217, 238, 18, 197, 138, 171, 68, 29, 15, 9, 143, 68, 226, 34, 30, 204, 218, 87, 2, 27, 74, 61, 165, 62, 152, 35, 104, 16, 95, 246, 34, 90, 42, 136, 189, 165, 247, 73, 148, 155, 55, 236, 82, 5, 200, 238, 203, 93, 233, 115, 207, 144, 169, 31 },
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
