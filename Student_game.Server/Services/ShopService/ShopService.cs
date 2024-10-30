using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.ShopService
{
    public class ShopService : IShopService
    {
        // tak jak wczesniej weapon do poprawy, wiecej info w interfejsie 
        public Task<ServiceResponse<Weapon>> BuyItem(int ItemID, int StudentID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Weapon>> SellItem(int ItemID, int StudentID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Weapon>> ShowRandomDailyDeal()
        {
            throw new NotImplementedException();
        }
    }
}