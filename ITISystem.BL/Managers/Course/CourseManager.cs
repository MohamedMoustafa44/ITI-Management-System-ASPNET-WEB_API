using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public class CourseManager : ICourseManager
{
    private readonly ICourseRepo _courseRepo;

    public CourseManager(ICourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }

    public List<CourseReadDto>? GetAllCourses()
    {
        List<CourseReadDto>? courseReadDtos = _courseRepo?.GetAllCourses()?.Select(crs => new CourseReadDto
        {
            Id = crs.Id,
            Name = crs.Name,
            TotalHours = crs.TotalHours,
        }).ToList();
        return courseReadDtos;
    }

    public CourseReadDto? GetCourseById(int id)
    {
        Course? course = _courseRepo?.GetCourseById(id);
        if (course == null)
        {
            return null;
        }
        CourseReadDto? courseRead = new CourseReadDto
        {
            Id = course.Id,
            Name = course.Name,
            TotalHours = course.TotalHours,
        };
        return courseRead;
    }

    public CourseReadDto? GetCourseByName(string name)
    {
        Course? course = _courseRepo.GetCourseByName(name);
        if (course == null)
        {
            return null;
        }
        CourseReadDto courseReadDto = new CourseReadDto
        {
            Id = course.Id,
            Name = course.Name,
            TotalHours = course.TotalHours,
        };
        return courseReadDto;
    }

    public void AddNewCourse(CourseAddDto newCourse)
    {
        Course? course = new Course
        {
            Name = newCourse.Name,
            TotalHours = newCourse.TotalHours,
        };
        _courseRepo.AddNewCourse(course);
    }

    public bool DeleteCourse(int id)
    {
        bool isDeleted = _courseRepo.DeleteCourse(id);
        return isDeleted;
    }

    public bool UpdateCourse(CourseUpdateDto courseToUpdate)
    {
        Course? course = _courseRepo.GetCourseById(courseToUpdate.Id);
        if (course == null)
        {
            return false;
        }
        course.Name = courseToUpdate.Name;
        course.TotalHours = courseToUpdate.TotalHours;
        _courseRepo.UpdateCourse(course);
        return true;

    }
}
