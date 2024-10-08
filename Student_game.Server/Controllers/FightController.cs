using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttackController: ControllerBase
    {
        private readonly IFightService _fightService;

        // public FightController(IFightService fightService)
        // {
        //     _fightService = fightService;
        // }

        // [HttpPost]
        // public async Task Task<IActionResult> WeaponAttack()
        // {
        //     return Ok(await _fightService.)
        // }
    }
}