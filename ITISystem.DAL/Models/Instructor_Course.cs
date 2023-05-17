using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.DAL;

public class Instructor_Course
{
    [Column(Order = 0)]
    public int InstructorId { get; set; }

    [Column(Order = 1)]
    public int CourseId { get;set; }

    [ForeignKey("InstructorId")]
    public Instructor? Instructor { get; set;}

    [ForeignKey("CourseId")]
    public Course? Course { get; set; }

    [Range(0, 5, ErrorMessage = "Rate out of range (1:5)")]
    public int Rate { get; set; }
}
