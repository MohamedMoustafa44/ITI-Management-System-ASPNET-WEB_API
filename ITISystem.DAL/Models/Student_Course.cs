using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.DAL;

public class Student_Course
{
    [Column(Order = 0)]
    public int StudentId { get; set; }

    [Column(Order = 1)]
    public int CourseId { get; set; }

    [ForeignKey("StudentId")]
    public Student? Student { get; set; }

    [ForeignKey("CourseId")]
    public Course? Course { get; set; }

    [Range(1, 100, ErrorMessage = "Out of range grade!")]

    public int Grade { get; set; }
}
