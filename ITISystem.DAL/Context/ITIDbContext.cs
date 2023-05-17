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
            .HasKey(c => new { c.InstructorId, c.CourseId });
    }
}
