using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISystem.DAL;

public class Department
{
    #region Department Properties
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    [Range(1, 50, ErrorMessage = "The capacity is between 1 and 50 students only")]
    public int Capacity { get; set; }
    #endregion

    #region Relations
    public int SupervisorId { get; set; }
    [ForeignKey("SupervisorId")]
    public Instructor? Supervisor { get; set; }
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    #endregion

}
