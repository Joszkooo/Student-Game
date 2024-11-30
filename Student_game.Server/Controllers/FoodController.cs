using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController: ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById (int id)
        {
            return Ok(new JsonResult(await _foodService.GetFoodById(id)));
        }

        [HttpGet]
        [Route("GetAllFood")]
        public async Task<IActionResult> GetAllFood ()
        {
            return Ok(new JsonResult(await _foodService.GetAllFood()));
        }
    }
}