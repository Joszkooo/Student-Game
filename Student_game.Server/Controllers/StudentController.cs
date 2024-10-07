using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService StudentService)
        {
            _studentService = StudentService;
        }
        
        [HttpGet]
        [Route("GetStudentById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            return Ok(new JsonResult(await _studentService.GetStudentById(id)));
        }

        [HttpGet]
        [Route("GetStudentEquipment")]
        public async Task<IActionResult> GetStudentEquipment(int id)
        {
            return Ok(new JsonResult(await _studentService.GetStudentEquipment(id)));
        }
    }
}