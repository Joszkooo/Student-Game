using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatController: ControllerBase
    {
        private readonly IStatService _statService;

        public StatController(IStatService statService)
        {
            _statService = statService;
        }
        [HttpGet("GetAllStats")]
        public async Task<IActionResult> GetAllStats()
        {
            return Ok(new JsonResult(await _statService.GetAllStats()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatByStudentId(int id)
        {
            return Ok(new JsonResult(await _statService.GetStatByStudentId(id)));
        }

        [HttpPost]
        [Route("IncrementDefeats")]
        public async Task<IActionResult> IncrementDefeats(int id)
        {
            return Ok(new JsonResult(await _statService.IncrementDefeats(id)));
        }

        [HttpPost]
        [Route("IncrementVictories")]
        public async Task<IActionResult> IncrementVictories(int id)
        {
            return Ok(new JsonResult(await _statService.IncrementVictories(id)));
        }
    }
}