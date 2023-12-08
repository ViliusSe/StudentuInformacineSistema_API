using Microsoft.AspNetCore.Mvc;
using SIS.DTO;
using SIS.Entities;
using SIS.Interfaces;
using SIS.Services;

namespace SIS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class DepartmentController : ControllerBase
    {
        //Injecting Department service and Logger dependency
        private readonly IDepartmentService _service;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService service, ILogger<DepartmentController> logger)
        {
            _service = service;
            _logger = logger;
        }


        //CRUD REQUESTS
        [HttpPost]
        public async Task<IActionResult>CreateDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_service.AddDepartment(department.name));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsList()
        {
            try
            {
                return Ok(_service.GetAllDepartments());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_service.GetDepartment(department.id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_service.UpdateDepartment(department.id, department.name));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Seri Log is Working");
                return BadRequest(ex);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_service.DeleteDepartment(department.id));
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
        public async Task<IActionResult> AddLecture([FromBody] DepartmentLectures dep_lec)
        {
            try
            {
                return Ok(_service.AddLecture(dep_lec.departments_id, dep_lec.lectures_id));
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
