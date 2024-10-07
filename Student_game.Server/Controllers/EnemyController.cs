using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemyController: ControllerBase
    {
        private readonly IEnemyService _enemyService;

        public EnemyController(IEnemyService enemyService)
        {
            _enemyService = enemyService;
        }

        [HttpGet]
        [Route("GetEnemyById")]
        public async Task<JsonResult> GetEnemyById(int id)
        {
            return new JsonResult(await _enemyService.GetEnemyById(id));
        }
        
        [HttpGet]
        [Route("GetRandomEnemy")]
        public async Task<JsonResult> GetRandomEnemy()
        {
            return new JsonResult(await _enemyService.GetRandomEnemy());
        
        }
    }
}