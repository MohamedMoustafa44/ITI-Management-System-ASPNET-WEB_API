using ITISystem.DAL;
using ITISystem.DTO;
using ITISystem.DTO.Student;

namespace ITISystem.BL;

public interface IStudentManager
{
    public List<StudentReadDto>? GetAllStudents();
    public StudentReadDto? GetStudentById(int id);
    public StudentReadDto? GetStudentByName(string name);
    public StudentWithDepartmentReadDto? GetStudentWithDepartment(int id);
    public void AddNewStudent(StudentAddDto newStudent);
    public bool DeleteStudent(int id);
    public bool UpdateStudent(StudentUpdateDto StudentToUpdate);
}
