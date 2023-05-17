using ITISystem.DAL;
using ITISystem.DTO;
using ITISystem.DTO.Student;

namespace ITISystem.BL;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepo _studentRepo;

    public StudentManager(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public List<StudentReadDto>? GetAllStudents()
    {
        List<Student>? studentsList = _studentRepo.GetStudents();
        if (studentsList == null)
        {
            return null;
        }
        List<StudentReadDto>? studentsReadDtos = studentsList?.Select(student => new StudentReadDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            Phone = student.Phone,
        }).ToList();

        return studentsReadDtos;
    }

    public StudentReadDto? GetStudentById(int id)
    {
        Student? student = _studentRepo.GetStudentById(id);
        if (student == null)
        {
            return null;
        }
        return new StudentReadDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            Phone = student.Phone,

        };
    }

    public StudentReadDto? GetStudentByName(string name)
    {
        Student? student = _studentRepo.GetStudentByName(name);
        if (student == null)
        {
            return null;
        }
        return new StudentReadDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            Phone = student.Phone,
        };

    }

    public StudentWithDepartmentReadDto? GetStudentWithDepartment(int id)
    {
        Student? student = _studentRepo.GetStudentWithDepartment(id);
        if (student == null || student.Department == null)
        {
            return null;
        }
        return new StudentWithDepartmentReadDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            Phone = student.Phone,
            Department = new DepartmentReadDto
            {
                Id = student.Department.Id,
                Name = student.Department.Name,
                Capacity = student.Department.Capacity,
            }
        };
    }
    public void AddNewStudent(StudentAddDto newStudent)
    {
        if (newStudent == null)
        {
            return;
        }
        Student student = new Student
        {
            Name = newStudent.Name,
            Age = newStudent.Age,
            Email = newStudent.Email,
            Phone = newStudent.Phone,
            DepartmentId = newStudent.DeptId,
        };
        _studentRepo.AddStudent(student);
    }
    public bool DeleteStudent(int id)
    {
        bool isDeleted =_studentRepo.DeleteStudent(id);
        return isDeleted;
        
    }

    public bool UpdateStudent(StudentUpdateDto StudentToUpdate)
    {
        Student? student = _studentRepo.GetStudentById(StudentToUpdate.Id);
        if (student == null) { return false; }
        student.Name = StudentToUpdate.Name;
        student.Age = StudentToUpdate.Age;
        student.Email = StudentToUpdate.Email;
        student.Phone = StudentToUpdate.Phone;
        _studentRepo.UpdateStudent(student);
        return true;

    }
}
