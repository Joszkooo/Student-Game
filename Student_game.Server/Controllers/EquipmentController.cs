using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_game.Server.Services.EquipmentService;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost("EquipWeapon")]
        public async Task<IActionResult> EquipWeapon(GetEquipmentServiceDTO studentItem)
        {
            return Ok(new JsonResult(await _equipmentService.EquipWeapon(studentItem)));
        }

        [HttpPost("EquipArmour")]
        public async Task<IActionResult> EquipArmour(GetEquipmentServiceDTO studentItem)
        {
            return Ok(new JsonResult(await _equipmentService.EquipArmour(studentItem)));
        }
    }
}