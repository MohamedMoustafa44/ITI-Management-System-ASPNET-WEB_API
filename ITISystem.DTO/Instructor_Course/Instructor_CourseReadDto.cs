namespace ITISystem.DTO;

public class Instructor_CourseReadDto
{
    public string StudentName { get; set; } = string.Empty;
    public string InstructorName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public int Rate { get; set; }
}
