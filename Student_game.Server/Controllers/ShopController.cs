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

        [HttpPost("BuyItem{ItemID}For{StudentID}")]
        public async Task<IActionResult> BuyItem(int ItemID, int StudentID)
        {
            return Ok(new JsonResult(await _shopService.BuyItem(ItemID, StudentID)));
        }

        
        [HttpPost("SellItem{ItemID}From{StudentID}")]
        public async Task<IActionResult> SellItem(int ItemID, int StudentID)
        {
            return Ok(new JsonResult(await _shopService.BuyItem(ItemID, StudentID)));
        }

        [HttpGet("ShowRandomDailyDeal")]
        public async Task<IActionResult> ShowRandomDailyDeal()
        {
            return Ok(new JsonResult(await _shopService.ShowRandomDailyDeal()));
        }
    }
}