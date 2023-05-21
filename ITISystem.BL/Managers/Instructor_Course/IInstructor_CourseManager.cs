using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public interface IInstructor_CourseManager
{
    public List<Instructor_CourseReadDto>? GetAllRates();
    public Instructor_CourseReadDto? GetRateByStdIdInstIdCrsId(int stdId, int instId, int crsId);
    public List<Instructor_CourseReadDto>? GetRateByStdIdInstId(int stdId, int instId);
    public List<Instructor_CourseReadDto>? GetRateByStdIdCrsId(int stdId, int crsId);
    public List<Instructor_CourseReadDto>? GetRateByInstIdCrsId(int instId, int crsId);
    public List<Instructor_CourseReadDto>? GetRatesByInstId(int instId);
    public List<Instructor_CourseReadDto>? GetRatesByCrsId(int crsId);
    public List<Instructor_CourseReadDto>? GetRatesByStdId(int stdId);
}
