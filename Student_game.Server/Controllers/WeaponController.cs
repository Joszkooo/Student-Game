using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_game.Server.Services.WeaponService;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponController: ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeaponById(int id)
        {
            return Ok(new JsonResult(await _weaponService.GetWeaponById(id)));
        }

        [HttpGet]
        [Route("GetAllWeapon")]
        public async Task<IActionResult> GetAllWeapon()
        {
            return Ok(new JsonResult(await _weaponService.GetAllWeapon()));
        }
    }
}