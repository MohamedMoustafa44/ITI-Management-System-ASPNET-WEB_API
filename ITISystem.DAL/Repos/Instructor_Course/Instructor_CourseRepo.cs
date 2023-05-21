using Microsoft.EntityFrameworkCore;

namespace ITISystem.DAL;

public class Instructor_CourseRepo : IInstructor_CourseRepo
{
    private readonly ITIDbContext _context;
    private IInstructorRepo _instructorRepo;
    private ICourseRepo _courseRepo;
    private IStudentRepo _studentRepo;
    public Instructor_CourseRepo(ITIDbContext context, IInstructorRepo instructorRepo, ICourseRepo courseRepo, IStudentRepo studentRepo)
    {
        _context = context;
        _instructorRepo = instructorRepo;
        _courseRepo = courseRepo;
        _studentRepo = studentRepo;
    }

    public string AddRateForInstructor(int StudentId, int InstructorId, int CourseId, int Rate)
    {
        Instructor_Course newInst_Course = new Instructor_Course();

        Student? student = _studentRepo.GetStudentById(StudentId);
        if (student == null)
        {
            return "Student Not Found!";
        }

        Instructor? instructor = _instructorRepo.GetInstructorById(InstructorId);
        if (instructor == null)
        {
            return "Instructor Not Found!";
        }

        Course? course = _courseRepo.GetCourseById(CourseId);
        if (course == null)
        {
            return "Course Not Found!";
        }

        newInst_Course.StudentId = StudentId;
        newInst_Course.InstructorId = InstructorId;
        newInst_Course.CourseId = CourseId;
        newInst_Course.Rate = Rate;

        _context.Set<Instructor_Course>().Add(newInst_Course);
        _context.SaveChanges();

        return "Sucess";
    }

    public bool DeleteRateForInstructor(int StudentId, int InstructorId, int CourseId)
    {
        Instructor_Course? Inst_CourseToDelete = _context.Set<Instructor_Course>()
                                                         .FirstOrDefault(inst_crs => inst_crs.StudentId == StudentId
                                                                                     &&
                                                                                     inst_crs.InstructorId == InstructorId
                                                                                     &&
                                                                                     inst_crs.CourseId == CourseId);
        if (Inst_CourseToDelete == null)
        {
            return false;
        }

        _context.Set<Instructor_Course>().Remove(Inst_CourseToDelete);
        _context.SaveChanges();

        return true;
    }

    public List<Instructor_Course>? GetAllRates()
    {
        return _context.Set<Instructor_Course>()
            .Include(inst_crs => inst_crs.Student)
            .Include(inst_crs => inst_crs.Course)
            .Include(inst_crs => inst_crs.Instructor)
            .ToList();
    }

    public List<Instructor_Course>? GetRateByCrsId(int crstId)
    {
        List<Instructor_Course>? instructors_Course = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.CourseId == crstId)
                                                                .ToList();
        return instructors_Course;
    }

    public List<Instructor_Course>? GetRateByInstId(int instId)
    {
        List<Instructor_Course>? instructor_Courses = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.InstructorId == instId)
                                                                .ToList();
        return instructor_Courses;
    }

    public List<Instructor_Course>? GetRateByStdId(int stdId)
    {
        List<Instructor_Course>? Student_Rates = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.StudentId == stdId)
                                                                .ToList();
        return Student_Rates;
    }

    public List<Instructor_Course>? GetRateByStdIdInstId(int stdId, int instId)
    {
        List<Instructor_Course>? Student_Instructor_Courses = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.StudentId == stdId
                                                                                   &&
                                                                                   inst_crs.InstructorId == instId)
                                                                .ToList();
        return Student_Instructor_Courses;
    }
    public List<Instructor_Course>? GetRateByStdIdCrsId(int stdId, int crsId)
    {
        List<Instructor_Course>? Student_Instructors_Course = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.StudentId == stdId
                                                                                   &&
                                                                                   inst_crs.CourseId == crsId)
                                                                .ToList();
        return Student_Instructors_Course;
    }

    public List<Instructor_Course>? GetRateByInstIdCrsId(int instId, int crsId)
    {
        List<Instructor_Course>? Students_Instructor_Course = _context.Set<Instructor_Course>()
                                                                .Include(inst_crs => inst_crs.Student)
                                                                .Include(inst_crs => inst_crs.Instructor)
                                                                .Include(inst_crs => inst_crs.Course)
                                                                .Where(inst_crs => inst_crs.InstructorId == instId
                                                                                   &&
                                                                                   inst_crs.CourseId == crsId)
                                                                .ToList();
        return Students_Instructor_Course;
    }

    public Instructor_Course? GetRateByStdIdInstIdCrsId(int stdId, int instId, int crsId)
    {
        return _context.Set<Instructor_Course>()
            .Include(inst_crs => inst_crs.Student)
            .Include(inst_crs => inst_crs.Instructor)
            .Include(inst_crs => inst_crs.Course)
            .FirstOrDefault(inst_crs => inst_crs.StudentId == stdId 
                                        &&
                                        inst_crs.InstructorId == instId
                                        &&
                                        inst_crs.CourseId == crsId);
    }
}
