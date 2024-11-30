using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FoodService
{
    public class FoodService: IFoodService
    {
        private readonly DataContext _context;

        public FoodService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Food>>> GetAllFood()
        {
            var serviceResponse = new ServiceResponse<List<Food>>();
            try
            {
                List<Food> dbFoods = await _context.Foods.ToListAsync();
                if (dbFoods is not null)
                {
                    serviceResponse.Data = dbFoods;
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak jedzenia w bazie danych";
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

        public async Task<ServiceResponse<Food>> GetFoodById(int id)
        {
            var serviceResponse = new ServiceResponse<Food>();
            try
            {
                var dbFoodsId = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
                if (dbFoodsId is not null)
                {
                    serviceResponse.Data = dbFoodsId;
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak jedzenia o Id {id}";
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