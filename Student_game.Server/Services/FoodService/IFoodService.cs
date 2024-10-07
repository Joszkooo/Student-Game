using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FoodService
{
    public interface IFoodService
    {
        Task<ServiceResponse<Food>> GetFoodById (int id);
        Task<ServiceResponse<List<Food>>> GetAllFood ();
    
    }
}