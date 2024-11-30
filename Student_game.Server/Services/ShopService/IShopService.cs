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
        Task<ServiceResponse<ItemDTO>> BuyItem(PickItemDTO requestedItem);
        Task<ServiceResponse<Weapon>> SellWeapon(int StudentID, int ItemID);
        Task<ServiceResponse<Food>> SellFood(int StudentID, int ItemID);
        Task<ServiceResponse<Armour>> SellArmour(int StudentID, int ItemID);
    }
}