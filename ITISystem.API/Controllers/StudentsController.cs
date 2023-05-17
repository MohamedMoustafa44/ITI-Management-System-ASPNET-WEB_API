using ITISystem.BL;
using ITISystem.DTO;
using ITISystem.DTO.Student;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentManager _studentManager;

    public StudentsController(IStudentManager studentManager)
    {
        _studentManager = studentManager;
    }

    [HttpGet]
    public ActionResult<List<StudentReadDto>?> GetAllStudents()
    {
        List<StudentReadDto>? studentReadDtos = _studentManager.GetAllStudents();
        if (studentReadDtos == null)
        {
            return NotFound();
        }
        return studentReadDtos;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<StudentReadDto> GetStudentById(int id)
    {
        StudentReadDto? student = _studentManager.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }

    [HttpGet]
    [Route("Name/{name}")]
    public ActionResult GetStudentByName(string name)
    {
        StudentReadDto? student = _studentManager.GetStudentByName(name);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpGet]
    [Route("StudentWithDepartment/{id}")]
    public ActionResult<StudentWithDepartmentReadDto> GetStudentWithDepartment(int id)
    {
        StudentWithDepartmentReadDto? studentWithDepartment = _studentManager.GetStudentWithDepartment(id);
        if (studentWithDepartment == null)
        {
            return NotFound();
        }
        return studentWithDepartment;
    }

    [HttpPost]
    public ActionResult AddNewStudent(StudentAddDto newStudent)
    {
        if (newStudent == null)
        {
            return BadRequest();
        }
        _studentManager.AddNewStudent(newStudent);
        return Ok(newStudent);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteStudent(int id)
    {
        bool isDeleted = _studentManager.DeleteStudent(id);
        if (!isDeleted)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateStudent(StudentUpdateDto student)
    {
        bool isFound = _studentManager.UpdateStudent(student);
        if (!isFound)
        {
            return NotFound();
        }
        return Ok();
    }
}
