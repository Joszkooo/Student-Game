using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.StatService
{
    public class StatService : IStatService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StatService(DataContext dataContext, IMapper autoMapper)
        {
            _context = dataContext;
            _mapper = autoMapper;
        }
        public async Task<ServiceResponse<GetStatDTO>> GetStatByStudentId(int id)
        {
            var serviceResponse = new ServiceResponse<GetStatDTO>(); 
            try
            {
                var stats = await _context.Stats.FirstOrDefaultAsync(x => x.Id == id);
                if (stats is not null)
                {

                    // WPIERDOLIC W CHATA W JAKI SPOSOB DODAC NICKNAME DO GETSTATDTO JESLI GO NIE MA W MODELU STATS 
                    // GetStatDTO stat = new GetStatDTO{Id = stas.id, Name = stats.Name}; //
                    serviceResponse.Data = _mapper.Map<GetStatDTO>(stats);
                    
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak statystyk dla studenta o {id} id";
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
                serviceResponse.Data = _mapper.Map<Stat>(DbOutcome);
                
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
                serviceResponse.Data = _mapper.Map<Stat>(DbOutcome);
                
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