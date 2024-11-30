using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Student_game.Server.Controllers
{
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost("BuyItem")]
        public async Task<IActionResult> BuyItem(PickItemDTO requestedItem)
        {
            return Ok(new JsonResult(await _shopService.BuyItem(requestedItem)));
        }

        
        [HttpPost("SellWeapon")]
        public async Task<IActionResult> SellWeapon(int StudentID, int ItemID)
        {
            return Ok(new JsonResult(await _shopService.SellWeapon(StudentID, ItemID)));
        }

        [HttpPost("SellFood")]
        public async Task<IActionResult> SellFood(int StudentID, int ItemID)
        {
            return Ok(new JsonResult(await _shopService.SellFood(StudentID, ItemID)));
        }

        [HttpPost("SellArmour")]
        public async Task<IActionResult> SellArmour(int StudentID, int ItemID)
        {
            return Ok(new JsonResult(await _shopService.SellArmour(StudentID, ItemID)));
        }
        
    }
}