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
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult>AddDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_service.AddDepartment(department.name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }

        }


    }
}
