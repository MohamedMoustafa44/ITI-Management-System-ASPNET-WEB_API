using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.DAL;

public class Course
{
    #region Course Properties
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TotalHours { get; set; }
    #endregion

    #region Relations
    public ICollection<Instructor_Course> Instructors_Courses { get; set; } = new HashSet<Instructor_Course>();
    public ICollection<Student_Course> Students_Courses { get; set; } = new HashSet<Student_Course>();
    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    #endregion
}
