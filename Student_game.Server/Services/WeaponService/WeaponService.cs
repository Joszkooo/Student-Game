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
                var weapon = await _context.Weapons.FirstOrDefaultAsync(x => x.Id == id);
                if (weapon is not null){
                    serviceResponse.Data = _mapper.Map<Weapon>(weapon);
                    return serviceResponse;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak broni o określonym id";
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