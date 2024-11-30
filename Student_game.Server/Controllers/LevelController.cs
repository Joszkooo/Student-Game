using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelController: ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        
        [HttpPatch("IncrementLvlPoints{studentId}")]
        public async Task<IActionResult> IncrementLevelPoints(int studentId, List<int> points)
        {
            return Ok(new JsonResult(await _levelService.IncrementLevelPoints(studentId, points)));
        }

        [HttpPatch("CheckLvlUp{studentId}")]
        public async Task<IActionResult> CheckIfLevelUp(int studentId)
        {
            return Ok(new JsonResult(await _levelService.CheckIfLevelUp(studentId)));
        }
    }
}