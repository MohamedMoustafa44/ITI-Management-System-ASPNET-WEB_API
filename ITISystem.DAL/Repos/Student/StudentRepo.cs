using Microsoft.EntityFrameworkCore;

namespace ITISystem.DAL;

public class StudentRepo : IStudentRepo
{
    private readonly ITIDbContext _context;

    public StudentRepo(ITIDbContext context)
    {
        _context = context;
    }

    public List<Student>? GetStudents()
    {
        return _context.Students.Include(std => std.Department).ToList();
    }

    public Student? GetStudentById(int id)
    {
        return _context.Set<Student>().FirstOrDefault(x => x.Id == id);
    }

    public Student? GetStudentByName(string name)
    {
        return _context.Set<Student>().FirstOrDefault(x => x.Name == name);
    }

    public Student? GetStudentWithDepartment(int id)
    {
        return _context.Set<Student>().Include(std => std.Department).FirstOrDefault(std => std.Id == id);
    }

    public void AddStudent(Student newStudent)
    {
        _context.Set<Student>().Add(newStudent);
        _context.SaveChanges();
    }

    public bool DeleteStudent(int id)
    {
        Student? studentToDelete = _context.Set<Student>().FirstOrDefault(std => std.Id == id);
        if (studentToDelete == null)
        {
            return false;
        }
        _context.Set<Student>().Remove(studentToDelete);
        _context.SaveChanges();
        return true;
    }

    public void UpdateStudent(Student studentToUpdate)
    {
        _context.SaveChanges();
    }
}
