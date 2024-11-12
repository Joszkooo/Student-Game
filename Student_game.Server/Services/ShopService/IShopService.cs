using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.ShopService
{
    public interface IShopService
    {
        // ten weapon do poprawy -> chcemy moc sprzedac dowolny przedmiot
        // problem jest taki ze musimy wiedziec jaki to jest przedmiot zeby go sprzedac
        Task<ServiceResponse<Object>> BuyItem(int ItemID, int StudentID);
        Task<ServiceResponse<Object>> SellItem(int ItemID, int StudentID);
        Task<ServiceResponse<Object>> ShowRandomDailyDeal();
    }
}