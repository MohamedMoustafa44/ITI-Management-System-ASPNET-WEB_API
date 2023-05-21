using ITISystem.DTO;

namespace ITISystem.BL;

public interface IInstructor_CourseManager
{
    public List<Instructor_CourseReadDto>? GetAllRates();
    public List<Instructor_CourseReadDto>? GetRatesByInstId(int instId);
    public List<Instructor_CourseReadDto>? GetRatesByCrsId(int crsId);
    public List<Instructor_CourseReadDto>? GetRatesByStdId(int stdId);
}
