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

        [HttpPost("FightOnline")]
        public async Task<IActionResult> FightOnline(FightCharactersDTO characters)
        {  
            return Ok(new JsonResult(await _fightService.FightOnline(characters)));
        }

        [HttpPost("FightLocally")]
        public async Task<IActionResult> FightLocally(FightCharactersDTO characters)
        {
            return Ok(new JsonResult(await _fightService.FightLocally(characters)));
        }
    }
}