using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpGet]
        [Route("GetAccount")]
        public async Task<JsonResult> GetAccount(int id)
        {
            return new JsonResult(await _accountService.GetAccount(id));
        }
        
    }
}