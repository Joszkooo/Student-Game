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
        private readonly DataContext _context;

        public AccountController(IAccountService accountService, DataContext context)
        {
            _accountService = accountService;
            _context = context;
        }

        // [HttpGet("signin-google")]
        // public IActionResult SingInGoogle()
        // {
        //     var redirectUrl = Url.Action("GoogleResponse", "Account");
        //     var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        //     return Challenge(properties, "Google");
        // }

        // [HttpGet("google-response")]
        // public async Task<IActionResult> GoogleResponse()
        // {
        //     var result = await HttpContext.AuthenticateAsync("Cookies");
        //     var claims = result.Principal?.Identities?.FirstOrDefault()?.Claims;

        //     var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        //     var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        //     if (email == null || name == null) return BadRequest("Failed to retrieve Google data");

        //     // Check if user exists
        //     var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);

        //     if (existingAccount == null)
        //     {
        //         var account = new Account
        //         {
        //             Name = name,
        //             Email = email,
        //             Nickname = name.Split(' ')[0],
        //             DateCreated = DateTime.UtcNow
        //         };
        //         var student = new Student();
        //         student.AccountId = account.Id;
        //         var studentStas = new Stat();
        //         studentStas.StudentId = student.Id;
        //         var studentWeapon = new Student_Weapon();
        //         studentWeapon.StudentId = student.Id;
        //         var studentFood = new Student_Food();
        //         studentFood.StudentId = student.Id;
        //         var studentArmour = new Student_Armour();
        //         studentArmour.Id = student.Id;


        //         _context.Accounts.Add(account);
        //         _context.Students.Add(student);
        //         _context.Stats.Add(studentStas);
        //         _context.Student_Weapons.Add(studentWeapon);
        //         _context.Student_Armors.Add(studentArmour);
        //         _context.Student_Foods.Add(studentFood);
        //         await _context.SaveChangesAsync();
        //     }

        //     return Redirect("/profile"); // Redirect to the appropriate frontend view
        // }
        
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