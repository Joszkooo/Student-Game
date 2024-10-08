using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArmourController : ControllerBase
    {
        private readonly IArmourService _armourService;

        public ArmourController(IArmourService armourService)
        {
            _armourService = armourService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArmourById(int id)
        {
            return Ok(new JsonResult(await _armourService.GetArmourById(id)));
        }

        [HttpGet]
        [Route("GetAllArmour")]
        public async Task<IActionResult> GetAllArmour()
        {
            return Ok(new JsonResult(await _armourService.GetAllArmour()));
        }
    }
}