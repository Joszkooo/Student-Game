using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FightController: ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }


        [HttpGet("PlayerAttack{PlayerId}")]
        public async Task<IActionResult> PlayerAttack(int PlayerId)
        {
            return Ok(new JsonResult(await _fightService.PlayerAttack(PlayerId)));
        }

        [HttpGet("SpecificEnemyAttack{EnemyId}")]
        public async Task<IActionResult> EnemyAttack(int EnemyId)
        {
            return Ok(new JsonResult(await _fightService.EnemyAttack(EnemyId)));
        }

        [HttpPost("Fight")]
        public async Task<IActionResult> Fight(int StudentId)
        {
            return Ok(new JsonResult(await _fightService.Fight(StudentId)));
        }
    }
}