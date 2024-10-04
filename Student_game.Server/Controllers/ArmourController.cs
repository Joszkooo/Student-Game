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

        [HttpGet]
        [Route("GetArmourById")]
        public async Task<JsonResult> GetArmourById(int id)
        {
            return new JsonResult(await _armourService.GetArmourById(id));
        }

        [HttpGet]
        [Route("GetAllArmour")]
        public async Task<JsonResult> GetAllArmour()
        {
            return new JsonResult(await _armourService.GetAllArmour());
        }
    }
}