using Microsoft.AspNetCore.Mvc;
using SIS.DTO;
using SIS.Interfaces;

namespace SIS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _service;

        public LectureController(ILectureService lectureService)
        {
            _service = lectureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLecture([FromBody] LectureDto lectureDto)
        {
            try
            {
                return Ok(_service.AddLecture(lectureDto.name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }

        }
    }
}
