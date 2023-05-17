using ITISystem.BL;
using ITISystem.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : ControllerBase
{
    private readonly IInstructorManager _instructorManager;

    public InstructorsController(IInstructorManager instructorManager)
    {
        _instructorManager = instructorManager;
    }

    [HttpGet]
    public ActionResult<List<InstructorReadDto>?> GetAllInstructors()
    {
        List<InstructorReadDto>? instructorReadDtos = _instructorManager.GetInstructors();
        if (instructorReadDtos == null)
        {
            return NotFound();
        }
        return instructorReadDtos;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<InstructorReadDto?> GetInstructorById(int id)
    {
        InstructorReadDto? instructorReadDto = _instructorManager.GetInstructorById(id);
        if (instructorReadDto == null)
        {
            return NotFound();
        }
        return instructorReadDto;
    }

    [HttpGet]
    [Route("Name/{name}")]
    public ActionResult<InstructorReadDto?> GetInstructorByName(string name)
    {
        InstructorReadDto? instructorReadDto = _instructorManager.GetInstructorByName(name);
        if (instructorReadDto == null)
        {
            return NotFound();
        }
        return instructorReadDto;
    }

    [HttpPost]
    public ActionResult AddNewInstructor(InstructorAddDto newInstructor)
    {
        if (newInstructor == null)
        {
            return BadRequest();
        }
        _instructorManager.AddInstructor(newInstructor);
        return Ok(newInstructor);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteInstructor(int id)
    {
        bool isDeleted = _instructorManager.DeleteInstructor(id);
        if (!isDeleted)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateInstructor(InstructorUpdateDto instructorToUpdate)
    {
        bool isUpdated = _instructorManager.UpdateInstructor(instructorToUpdate);
        if (!isUpdated)
        {
            return NotFound();
        }
        return Ok();
    }
}
