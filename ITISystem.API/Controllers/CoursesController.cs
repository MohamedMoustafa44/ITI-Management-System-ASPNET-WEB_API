using ITISystem.BL;
using ITISystem.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITISystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet]
        public ActionResult<List<CourseReadDto>?> GetCourses()
        {
            List<CourseReadDto>? courseReadDtos = _courseManager.GetAllCourses();
            if (courseReadDtos == null)
            {
                return NotFound();
            }
            return courseReadDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CourseReadDto?> GetCourseById(int id)
        {
            CourseReadDto? courseReadDto = _courseManager.GetCourseById(id);
            if (courseReadDto == null)
            {
                return NotFound();
            }
            return courseReadDto;
        }

        [HttpGet]
        [Route("Name/{name}")]
        public ActionResult<CourseReadDto?> GetCourseByName(string name)
        {
            CourseReadDto? courseReadDto = _courseManager.GetCourseByName(name);
            if (courseReadDto == null)
            {
                return NotFound();
            }
            return courseReadDto;
        }

        [HttpPost]
        public ActionResult AddNewCourse(CourseAddDto newCourse)
        {
            if (newCourse == null)
            {
                return BadRequest();
            }
            _courseManager.AddNewCourse(newCourse);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            bool isFound = _courseManager.DeleteCourse(id);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCourse(CourseUpdateDto courseToUpdate)
        {
            bool isFound = _courseManager.UpdateCourse(courseToUpdate);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
