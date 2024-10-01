using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims; // TODO <===== naucz sie co to


namespace Student_game.Server.Services.AccountService
{

    public class AccountService: IAccountService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<Account>> GetAccount(int id)
        {
            var serviceResponse = new ServiceResponse<Account>();
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
                if (account is not null)
                {
                    serviceResponse.Data = _mapper.Map<Account>(account);
                    return serviceResponse;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"No account with {id} is found.";
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
        }

    }
}