namespace ITISystem.DAL;

public interface IInstructor_CourseRepo
{
    public List<Instructor_Course>? GetAllRates();
    public Instructor_Course? GetRateByStdIdInstIdCrsId(int stdId, int instId, int crsId);
    public List<Instructor_Course>? GetRateByStdIdInstId(int stdId, int instId);
    public List<Instructor_Course>? GetRateByStdIdCrsId(int stdId, int crsId);
    public List<Instructor_Course>? GetRateByInstIdCrsId(int instId, int crsId);
    public List<Instructor_Course>? GetRateByInstId(int instId);
    public List<Instructor_Course>? GetRateByCrsId(int crstId);
    public List<Instructor_Course>? GetRateByStdId(int stdId);
    public string AddRateForInstructor(int StudentId, int InstructorId, int CourseId, int Rate);
    public bool DeleteRateForInstructor(int StudentId, int InstructorId, int CourseId);
}
