using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatController: ControllerBase
    {
        private readonly IStatService _statService;

        public StatController(IStatService statService)
        {
            _statService = statService;
        }

        [HttpGet]
        [Route("GetStatByStudentId")]
        public async Task<JsonResult> GetStatByStudentId(int id)
        {
            return new JsonResult(await _statService.GetStatByStudentId(id));
        }

        [HttpPost]
        [Route("IncrementDefeats")]
        public async Task<JsonResult> IncrementDefeats(int id)
        {
            return new JsonResult(await _statService.IncrementDefeats(id));
        }

        [HttpPost]
        [Route("IncrementVictories")]
        public async Task<JsonResult> IncrementVictories(int id)
        {
            return new JsonResult(await _statService.IncrementVictories(id));
        }
    }
}