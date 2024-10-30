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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int StudentId)
        {
            return Ok(new JsonResult(await _studentService.GetStudentById(StudentId)));
        }

        [HttpGet("GetStudentProfile{StudentId}")]
        public async Task<IActionResult> GetStudentProfile(int StudentId)
        {
            return Ok(new JsonResult(await _studentService.GetStudentProfile(StudentId)));
        }

        [HttpGet("GetStudentWeapon{StudentId}")]
        public async Task<IActionResult> GetStudentWeapon(int StudentId)
        {
            return Ok(new JsonResult(await _studentService.GetStudentWeapon(StudentId)));
        }        

        [HttpGet("GetStudentArmour{StudentId}")]
        public async Task<IActionResult> GetStudentArmour(int StudentId)
        {
            return Ok(new JsonResult(await _studentService.GetStudentArmour(StudentId)));
        }

        [HttpGet("GetStudentFood{StudentId}")]
        public async Task<IActionResult> GetStudentFood(int StudentId)
        {
            return Ok(new JsonResult(await _studentService.GetStudentFood(StudentId)));
        }

        [HttpGet("GetStudentEquipment{StudentId}")]
        public IActionResult GetStudentEquipment(int StudentId)
        {
            return Ok(new JsonResult(_studentService.GetStudentEquipment(StudentId)));
        }
    }
}