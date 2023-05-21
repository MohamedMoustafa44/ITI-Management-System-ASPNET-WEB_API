using ITISystem.BL;
using ITISystem.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsCoursesController : ControllerBase
    {
        private readonly IInstructor_CourseManager _instructor_CourseManager;

        public InstructorsCoursesController(IInstructor_CourseManager instructor_CourseManager)
        {
            _instructor_CourseManager = instructor_CourseManager;
        }

        [HttpGet]
        public ActionResult<List<Instructor_CourseReadDto>?> GetAllRates()
        {
            List<Instructor_CourseReadDto>? instructor_CourseReadDtos = _instructor_CourseManager.GetAllRates();
            if (instructor_CourseReadDtos == null)
            {
                return NotFound();
            }
            return instructor_CourseReadDtos;
        }

        [HttpGet]
        [Route("Instructor/{id}")]
        public ActionResult<List<Instructor_CourseReadDto>?> GetRatesByInstId(int id)
        {
            List<Instructor_CourseReadDto>? instructor_CourseReadDtos = _instructor_CourseManager.GetRatesByInstId(id);
            if (instructor_CourseReadDtos == null)
            {
                return NotFound();
            }
            return instructor_CourseReadDtos;
        }
    }
}
