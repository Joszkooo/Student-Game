using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace Student_game.Server.Services.StatService
{
    public class StatService : IStatService
    {
        private readonly DataContext _context;

        public StatService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ServiceResponse<List<Stat>>> GetAllStats()
        {
            var serviceResponse = new ServiceResponse<List<Stat>>(); 
            try
            {
                var stats = await _context.Stats
                    .ToListAsync();
                if (stats != null){
                    serviceResponse.Data = stats;
                }else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak statystyk w bazie danych";
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
        public async Task<ServiceResponse<GetStatDTO>> GetStatByStudentId(int id)
        {
            var serviceResponse = new ServiceResponse<GetStatDTO>(); 
            try
            {
                var stats = await _context.Stats
                    .Include(s => s.Student)
                        .ThenInclude(st => st.Account)
                            .FirstOrDefaultAsync(x => x.Id == id);
                if (stats is not null)
                {
                    GetStatDTO response = stats.Adapt<GetStatDTO>();
                    response.Nickname = stats.Student.Account.Nickname;
                    serviceResponse.Data = response;
                    
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak statystyk dla studenta o {id} id";
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

        public async Task<ServiceResponse<Stat>> IncrementDefeats(int id)
        {
            var serviceResponse = new ServiceResponse<Stat>();
            try
            {
                var DbOutcome = await _context.Stats.FirstOrDefaultAsync(x => x.Id == id);
                if (DbOutcome is not null){
                    DbOutcome.Defeats++;
                    DbOutcome.Fights++;
                }
                else throw new Exception($"Student z {id} id nie istnieje!");
                await _context.SaveChangesAsync();
                serviceResponse.Data = DbOutcome.Adapt<Stat>();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Stat>> IncrementVictories(int id)
        {
            var serviceResponse = new ServiceResponse<Stat>();
            try
            {
                var DbOutcome = await _context.Stats.FirstOrDefaultAsync(x => x.Id == id);
                if (DbOutcome is not null){
                    DbOutcome.Victories++;
                    DbOutcome.Fights++;
                }
                else throw new Exception($"Student z {id} id nie istnieje!");
                
                await _context.SaveChangesAsync();
                serviceResponse.Data = DbOutcome.Adapt<Stat>();
                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
            }
            return serviceResponse;
        }

    }
}