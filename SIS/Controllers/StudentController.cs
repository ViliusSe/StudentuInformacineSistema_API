using Microsoft.AspNetCore.Mvc;
using SIS.DTO;
using SIS.Entities;
using SIS.Interfaces;

namespace SIS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<StudentController> _logger;


        public StudentController(IStudentsService studentsService, ILogger<StudentController> logger)
        {
            _studentsService = studentsService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Seri Log is Working");
            try
            {
                return Ok(_studentsService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto student)
        {

            try
            {
                return Ok(_studentsService.AddStudent(student.name));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult>AddDepartment([FromBody] StudentDto student)
        {
            try
            {
                return Ok(_studentsService.AddDepartment(student.id, student.departments_id));
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
