using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Weapon>> GetWeaponById(int id)
        {
            var serviceResponse = new ServiceResponse<Weapon>();
            try
            {
                var dbWeapon = await _context.Weapons.FirstOrDefaultAsync(x => x.Id == id);
                if (dbWeapon is not null){
                    serviceResponse.Data = _mapper.Map<Weapon>(dbWeapon);
                    return serviceResponse;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak broni o {id} id";
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
        public async Task<ServiceResponse<List<Weapon>>> GetAllWeapon ()
        {
            var serviceResponse = new ServiceResponse<List<Weapon>>();
            try
            {
                var dbAllWeapon = await _context.Weapons.ToListAsync();
                if (dbAllWeapon is not null)
                {
                    serviceResponse.Data = dbAllWeapon;
                    
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak broni w bazie danych";
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