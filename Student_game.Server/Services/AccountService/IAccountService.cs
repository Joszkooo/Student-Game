using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<Account>> GetAccount(int id);
    }
}