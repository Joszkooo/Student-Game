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
        [Route("GetStudent")]
        public async Task<JsonResult> GetStudent(int id)
        {
            return new JsonResult(await _studentService.GetStudent(id));
        }
    }
}