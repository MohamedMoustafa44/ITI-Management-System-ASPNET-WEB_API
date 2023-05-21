using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.DAL;

public class Student : Person
{
    #region Relations
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Student_Course> Students_Courses { get; set; } = new HashSet<Student_Course>();
    public ICollection<Instructor_Course> Instructors_Courses { get; set; } = new HashSet<Instructor_Course>();
    #endregion
}
