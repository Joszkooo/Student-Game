using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.EnemyService
{
    public class EnemyService : IEnemyService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EnemyService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Enemy>> GetEnemyById(int id)
        {
            var serviceResponse = new ServiceResponse<Enemy>();
            try
            {
                var dbEnemy = await _context.Enemies.SingleOrDefaultAsync(x => x.Id == id); 
                if (dbEnemy is not null)
                {
                    serviceResponse.Data = dbEnemy;
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przeciwnika o {id} id";
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

        public async Task<ServiceResponse<Enemy>> GetRandomEnemy()
        {
            var serviceResponse = new ServiceResponse<Enemy>();
            try
            {
                int random;
                // searching for maxId in db and then getting random number of it
                var maxId = await _context.Enemies.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                if (maxId is not null) { 
                    random = new Random().Next(maxId.Id); }
                else {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Brak id w bazie Enemy!";
                    return serviceResponse;
                }
                var dbEnemy = await _context.Enemies.SingleOrDefaultAsync(x => x.Id == random); 
                if (dbEnemy is not null)
                {
                    serviceResponse.Data = dbEnemy;
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przeciwników w bazie!";
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