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

        public async Task<ServiceResponse<GetAccountDTO>> GetAccount(int AccountId)
        {
            var serviceResponse = new ServiceResponse<GetAccountDTO>();
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == AccountId);
                if (account is not null)
                {
                    serviceResponse.Data = account.Adapt<GetAccountDTO>();
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"No account with {AccountId} is found.";
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

        public async Task<ServiceResponse<Account>> DeleteAccount(int AccountId)
        {
            var serviceResponse = new ServiceResponse<Account>();
            try
            {
                var accountDB = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == AccountId);
                if (accountDB is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak konta o ID {AccountId}";
                    return serviceResponse;
                }

                _context.Attach(accountDB);
                _context.Remove(accountDB);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Usunieto konto pomyslnie";
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
        }
        // public async Task<ServiceResponse<Account>> MakeAccount(Account newAccount)
        // {
        //     var serviceResponse = new ServiceResponse<Account>();
        //     try
        //     {
        //         var account = newAccount.Adapt<Account>();
        //         await _context.Accounts.AddAsync(account);
        //         await _context.SaveChangesAsync();
        //         serviceResponse.Data = account;
        //         serviceResponse.Message = $"Poprawnie dodano konto z ID {newAccount.Id}";
        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Success = false;
        //         serviceResponse.Message = $"Error: {ex.Message}";
        //         return serviceResponse;
        //     }
        // }

        public async Task<ServiceResponse<List<Account>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<Account>>();
            try
            {
                var accountsDB = await _context.Accounts.ToListAsync();
                if (accountsDB.Any())
                {
                    serviceResponse.Data = accountsDB;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak kont w bazie danych.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }
    }
}