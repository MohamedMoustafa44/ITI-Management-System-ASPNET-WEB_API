using ITISystem.DTO;

namespace ITISystem.BL;

public interface ICourseManager
{
    public List<CourseReadDto>? GetAllCourses();
    public CourseReadDto? GetCourseById(int id);
    public CourseReadDto? GetCourseByName(string name);
    public void AddNewCourse(CourseAddDto newCourse);
    public bool DeleteCourse(int id);
    public bool UpdateCourse(CourseUpdateDto courseToUpdate);
}
