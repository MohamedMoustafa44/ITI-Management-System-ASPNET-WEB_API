using System.ComponentModel.DataAnnotations;

namespace ITISystem.DTO;

public class DepartmentUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Range(1, 50, ErrorMessage = "The capacity is between 1 and 50 students only")]
    public int Capacity { get; set; }
}
