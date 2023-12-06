using Microsoft.AspNetCore.Mvc;
using SIS.Interfaces;

namespace SIS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentController( IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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
    }
}
