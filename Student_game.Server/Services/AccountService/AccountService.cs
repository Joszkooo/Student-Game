using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Student_game.Server.Services.AccountService
{

    public class AccountService: IAccountService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetAccountId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<GetAccountDTO>> GetAccount(int id)
        {
            var serviceResponse = new ServiceResponse<GetAccountDTO>();
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
                if (account is not null)
                {
                    serviceResponse.Data = account.Adapt<GetAccountDTO>();
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"No account with {id} is found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
        }

        public Task<ServiceResponse<Account>> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}