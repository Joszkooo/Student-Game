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

        [HttpGet("WeaponAttack{WeaponId, StudentId}")]
        public async Task<IActionResult> WeaponAttack(int WeaponId, int StudentId)
        {
            return Ok(new JsonResult(await _fightService.WeaponAttack(WeaponId, StudentId)));
        }

        [HttpGet("PlayerAttack{PlayerId}")]
        public async Task<IActionResult> PlayerAttack(int PlayerId)
        {
            return Ok(new JsonResult(await _fightService.PlayerAttack(PlayerId)));
        }

        [HttpGet("SpecificEnemyAttack{EnemyId}")]
        public async Task<IActionResult> SpecificEnemyAttack(int EnemyId)
        {
            return Ok(new JsonResult(await _fightService.SpecificEnemyAttack(EnemyId)));
        }

        [HttpGet("RandomEnemyAttack{enemy}")]
        public async Task<IActionResult> RandomEnemyAttack(Enemy enemy)
        {
            return Ok(new JsonResult(await _fightService.RandomEnemyAttack(enemy)));
        }

        [HttpPost("Fight")]
        public async Task<IActionResult> Fight()
        {
            return Ok(new JsonResult(await _fightService.Fight()));
        }
    }
}