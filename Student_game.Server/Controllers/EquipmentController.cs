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

        [HttpPost("EquipWeapon{StudentId}")]
        public async Task<IActionResult> EquipWeapon(int StudentId, int WeaponId)
        {
            return Ok(await _equipmentService.EquipWeapon(StudentId, WeaponId));
        }

        [HttpPost("EquipArmour{StudentId}")]
        public async Task<IActionResult> EquipArmour(int StudentId, int ArmourId)
        {
            return Ok(await _equipmentService.EquipArmour(StudentId, ArmourId));
        }

        [HttpPost("UseFood{StudentId}")]
        public async Task<IActionResult> UseFood(int StudentId, int FoodId)
        {
            return Ok(await _equipmentService.UseFood(StudentId, FoodId));
        }
    }
}