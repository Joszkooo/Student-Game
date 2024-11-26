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
        
        [HttpGet("Get{AccountId}")]
        public async Task<IActionResult> GetAccount(int AccountId)
        {
            return Ok(new JsonResult(await _accountService.GetAccount(AccountId)));
        }

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(new JsonResult(await _accountService.GetAllAccounts()));
        }

        [HttpDelete("Delete{AccountId}")]
        public async Task<IActionResult> DeleteAccount(int AccountId)
        {
            return Ok(new JsonResult(await _accountService.DeleteAccount(AccountId)));
        }

        // [HttpPost("MakeAccount")]
        // public async Task<IActionResult> MakeAccount(Account newAccount)
        // {
        //     return Ok(new JsonResult(await _accountService.MakeAccount(newAccount)));
        // }
        
    }
}