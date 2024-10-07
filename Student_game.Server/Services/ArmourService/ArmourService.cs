using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.ArmourService
{
    public class ArmourService : IArmourService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ArmourService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Armour>>> GetAllArmour()
        {
            var serviceResponse = new ServiceResponse<List<Armour>>();
            try
            {
                List<Armour> dbArmours = await _context.Armours.ToListAsync();
                if (dbArmours is not null)
                {
                    serviceResponse.Data = dbArmours;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak zbroi w bazie danych";
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

        public async Task<ServiceResponse<Armour>> GetArmourById(int id)
        {
            var serviceResponse = new ServiceResponse<Armour>();
            try
            {
                var dbArmoursId = await _context.Armours.FirstOrDefaultAsync(x => x.Id == id);
                if (dbArmoursId is not null)
                {
                    serviceResponse.Data = dbArmoursId;
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak zbroi o Id {id}";
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