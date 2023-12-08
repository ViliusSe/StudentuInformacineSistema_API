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

        //Injecting Student service and Logger dependency
        private readonly IStudentsService _studentsService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentsService studentsService, ILogger<StudentController> logger)
        {
            _studentsService = studentsService;
            _logger = logger;

        }

        //CRUD REQUESTS
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto student)
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

        [HttpGet]
        public async Task<IActionResult> GetStudentsList()
        {
            try
            {
                return Ok(_studentsService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent([FromBody] StudentDto student)
        {
            try
            {
                return Ok(_studentsService.GetStudent(student.id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        /*
         * UPDATE ir DELETE metodus reikia testuoti, jiems perduotas is karto pilnas objektas ne DTO !!!!!!!!!!!!!!!!!
         * UPDATE metoda reikia overridinti perduodant tik name arba tik department_id.
         */

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            try
            {
                return Ok(_studentsService.UpdateStudent(student.id, student.name, student.departments_id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromBody] Student student)
        {
            try
            {
                return Ok(_studentsService.DeleteStudent(student.id));
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
