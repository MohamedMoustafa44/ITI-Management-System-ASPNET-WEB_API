﻿// <auto-generated />
using ITISystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITISystem.DAL.Migrations
{
    [DbContext(typeof(ITIDbContext))]
    partial class ITIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "DepartmentsId");

                    b.HasIndex("DepartmentsId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("ITISystem.DAL.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ITISystem.DAL.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ITISystem.DAL.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITISystem.DAL.Instructor_Course", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "InstructorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Instructor_Course");
                });

            modelBuilder.Entity("ITISystem.DAL.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ITISystem.DAL.Student_Course", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Students_Courses");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("ITISystem.DAL.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITISystem.DAL.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITISystem.DAL.Department", b =>
                {
                    b.HasOne("ITISystem.DAL.Instructor", "Supervisor")
                        .WithOne("Department")
                        .HasForeignKey("ITISystem.DAL.Department", "SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("ITISystem.DAL.Instructor_Course", b =>
                {
                    b.HasOne("ITISystem.DAL.Course", "Course")
                        .WithMany("Instructors_Courses")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.HasOne("ITISystem.DAL.Instructor", "Instructor")
                        .WithMany("Instructors_Courses")
                        .HasForeignKey("InstructorId")
                        .IsRequired();

                    b.HasOne("ITISystem.DAL.Student", "Student")
                        .WithMany("Instructors_Courses")
                        .HasForeignKey("StudentId")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITISystem.DAL.Student", b =>
                {
                    b.HasOne("ITISystem.DAL.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ITISystem.DAL.Student_Course", b =>
                {
                    b.HasOne("ITISystem.DAL.Course", "Course")
                        .WithMany("Students_Courses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITISystem.DAL.Student", "Student")
                        .WithMany("Students_Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITISystem.DAL.Course", b =>
                {
                    b.Navigation("Instructors_Courses");

                    b.Navigation("Students_Courses");
                });

            modelBuilder.Entity("ITISystem.DAL.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ITISystem.DAL.Instructor", b =>
                {
                    b.Navigation("Department");

                    b.Navigation("Instructors_Courses");
                });

            modelBuilder.Entity("ITISystem.DAL.Student", b =>
                {
                    b.Navigation("Instructors_Courses");

                    b.Navigation("Students_Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
