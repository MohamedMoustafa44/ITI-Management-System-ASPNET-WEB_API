using ITISystem.BL;
using ITISystem.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentManager _departmentManager;

    public DepartmentsController(IDepartmentManager departmentManager)
    {
        _departmentManager = departmentManager;
    }

    [HttpGet]
    public ActionResult<List<DepartmentReadDto>?> GetAllDepartments()
    {
        List<DepartmentReadDto>? departmentReadDtos = _departmentManager.GetDepartments();
        if (departmentReadDtos == null)
        {
            return NotFound();
        }
        return departmentReadDtos;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<DepartmentReadDto?> GetDepartmentById(int id)
    {
        DepartmentReadDto? departmentReadDto = _departmentManager.GetDepartmentById(id);
        if (departmentReadDto is null)
        {
            return NotFound();
        }
        return departmentReadDto;
    }

    [HttpGet]
    [Route("Name/{name}")]
    public ActionResult<DepartmentReadDto?> GetDepartmentByName(string name)
    {
        DepartmentReadDto? departmentReadDto = _departmentManager.GetDepartmentByName(name);
        if (departmentReadDto == null)
        {
            return NotFound();
        }
        return departmentReadDto;
    }

    [HttpPost]
    public ActionResult AddNewDepartment(DepartmentAddDto newDepartment)
    {
        if (newDepartment == null)
        {
            return BadRequest();
        }
        _departmentManager.AddDepartment(newDepartment);
        return Ok(newDepartment);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteDepartment(int id)
    {
        bool isDeleted = _departmentManager.DeleteDepartment(id);
        if (!isDeleted)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateDepartment(DepartmentUpdateDto departmentToUpdate)
    {
        bool isFound = _departmentManager.UpdateDepartment(departmentToUpdate);
        if (!isFound)
        {
            return NotFound();
        }
        return Ok();
    }
}
