using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<GetAccountDTO>> GetAccount(int AccountId);
        Task<ServiceResponse<Account>> DeleteAccount(int AccountId);
        // Task<ServiceResponse<Account>> MakeAccount(Account newAccount);
        Task<ServiceResponse<List<Account>>> GetAllAccounts();
    }
}