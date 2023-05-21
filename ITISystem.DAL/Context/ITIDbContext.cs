using Microsoft.EntityFrameworkCore;

namespace ITISystem.DAL;

public class ITIDbContext:DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student_Course> Students_Courses { get; set; }
    public ITIDbContext(DbContextOptions<ITIDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student_Course>()
            .HasKey(c => new { c.CourseId, c.StudentId });

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Instructor_Course>()
            .HasKey(c => new { c.StudentId, c.InstructorId, c.CourseId });

        modelBuilder.Entity<Instructor_Course>()
            .HasOne(student => student.Student)
            .WithMany(inst_crs => inst_crs.Instructors_Courses)
            .HasForeignKey(std => std.StudentId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Instructor_Course>()
            .HasOne(instructor => instructor.Instructor)
            .WithMany(inst_crs => inst_crs.Instructors_Courses)
            .HasForeignKey(inst => inst.InstructorId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Instructor_Course>()
            .HasOne(course => course.Course)
            .WithMany(inst_crs => inst_crs.Instructors_Courses)
            .HasForeignKey(crs => crs.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
