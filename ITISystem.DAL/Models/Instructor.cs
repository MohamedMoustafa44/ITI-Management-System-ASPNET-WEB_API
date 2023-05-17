namespace ITISystem.DAL;

public class Instructor : Person
{
    #region Relations
    public Department? Department { get; set; }
    public ICollection<Instructor_Course> Instructors_Courses { get; set; } = new HashSet<Instructor_Course>();
    #endregion
}
