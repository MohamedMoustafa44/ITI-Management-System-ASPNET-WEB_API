namespace ITISystem.DAL;

public class CourseRepo : ICourseRepo
{
    private readonly ITIDbContext _context;

    public CourseRepo(ITIDbContext context)
    {
        _context = context;
    }

    public List<Course>? GetAllCourses()
    {
        return _context.Set<Course>().ToList();
    }

    public Course? GetCourseById(int id)
    {
        Course? course = _context.Set<Course>().FirstOrDefault(crs => crs.Id == id);
        return course;
    }

    public Course? GetCourseByName(string name)
    {
        Course? course = _context.Set<Course>().FirstOrDefault(crs => crs.Name == name);
        return course;
    }

    public void AddNewCourse(Course newCourse)
    {
        _context.Set<Course>().Add(newCourse);
        _context.SaveChanges();
    }

    public bool DeleteCourse(int id)
    {
        Course? courseToDelete = _context.Set<Course>().FirstOrDefault(c => c.Id == id);
        if (courseToDelete == null)
        {
            return false;
        }
        _context.Set<Course>().Remove(courseToDelete);
        _context.SaveChanges();
        return true;
    }

    public void UpdateCourse(Course courseToUpdate)
    {
        _context.SaveChanges();
    }
}
