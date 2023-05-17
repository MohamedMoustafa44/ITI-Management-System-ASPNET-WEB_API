namespace ITISystem.DAL;

public interface ICourseRepo
{
    public List<Course>? GetAllCourses();
    public Course? GetCourseById(int id);
    public Course? GetCourseByName(string name);
    public void AddNewCourse(Course newCourse);
    public bool DeleteCourse(int id);
    public void UpdateCourse(Course courseToUpdate);
}
