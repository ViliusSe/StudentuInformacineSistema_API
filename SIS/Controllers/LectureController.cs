using Microsoft.AspNetCore.Mvc;
using SIS.DTO;
using SIS.Entities;
using SIS.Interfaces;
using SIS.Services;

namespace SIS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LectureController : ControllerBase
    {
        //Injecting Lecture service and Logger dependency
        private readonly ILectureService _service; 
        private ILogger<LectureController> _logger;
        public LectureController(ILectureService lectureService, ILogger<LectureController> logger)
        {
            _service = lectureService;
            _logger = logger;
        }

        //CRUD REQUESTS
        [HttpPost]
        public async Task<IActionResult> CreateLecture([FromBody] LectureDto lecture)
        {
            try
            {
                return Ok(_service.AddLecture(lecture.name));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLecturesList()
        {
            try
            {
                return Ok(_service.GetAllLectures());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLecture([FromBody] LectureDto lecture)
        {
            try
            {
                return Ok(_service.GetLecture(lecture.id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLecture([FromBody] LectureDto lecture)
        {
            try
            {
                return Ok(_service.UpdateLecture(lecture.id, lecture.name));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLecture([FromBody] LectureDto lecture)
        {
            try
            {
                return Ok(_service.DeleteLecture(lecture.id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }


        //NON CRUD REQUESTS
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentLectures dep_lec)
        {
            try
            {
                return Ok(_service.AddDepartment(dep_lec.lectures_id, dep_lec.departments_id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]  StudentLectures stu_lec)
        {
            try
            {
                return Ok(_service.AddStudent(stu_lec.lectures_id, stu_lec.students_id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }
    }
}
