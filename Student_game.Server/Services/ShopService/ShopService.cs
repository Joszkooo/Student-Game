using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly DataContext _context;
        private readonly IStudentService _studentService;

        public ShopService(DataContext context,IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        // tak jak wczesniej weapon do poprawy, wiecej info w interfejsie 
        public Task<ServiceResponse<Object>> BuyItem(int ItemID, int StudentID)
        {
            throw new NotImplementedException();
            // var eq = _studentService.GetStudentEquipment(StudentID);
            // foreach (var weapon in eq)
            // {
            //     if (weapon.WeaponID == ItemID)
            //     {

            //     }
            // }
        }

        public async Task<ServiceResponse<Object>> SellItem(int ItemID, int StudentID, string ItemType)
        {
            throw new NotImplementedException();
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == StudentID);
            
            var eq = _studentService.GetStudentEquipment(StudentID).Data;

            if (ItemType == "Weapon")
            {
                var serviceResponse = new ServiceResponse<Weapon>();
                // foreach (var weapon in eq.Weapons)
                // {
                //     if (weapon.Id == ItemID)
                //     {
                //         
                //     }
                //     else {
                //         serviceResponse.Success = false;
                //         serviceResponse.Message = $"Brak przedmiotu {ItemID} w bazie danych.";
                //     }
                // }
                var item = eq.Weapons.Select(x => x.Id == ItemID);
                _context.Entry(item).State = EntityState.Deleted;
                // student.Money += item
                _context.SaveChanges();
            }
            else if (ItemType == "Armour")
            {
                var serviceResponse = new ServiceResponse<Armour>();
                foreach (var weapon in eq.Armors)
                {
                    if (weapon.Id == ItemID)
                    {
                        _context.Entry(weapon).State = EntityState.Deleted;
                        _context.SaveChanges();
                    }
                    else {
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Brak przedmiotu {ItemID} w bazie danych.";
                    }
                }
            }
            else
            {
                var serviceResponse = new ServiceResponse<Food>();
                foreach (var weapon in eq.Foods)
                {
                    if (weapon.Id == ItemID)
                    {
                        _context.Entry(weapon).State = EntityState.Deleted;
                        _context.SaveChanges();
                    }
                    else {
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Brak przedmiotu {ItemID} w bazie danych.";
                    }
                }
            }
        }

        public Task<ServiceResponse<object>> SellItem(int ItemID, int StudentID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Object>> ShowRandomDailyDeal()
        {
            throw new NotImplementedException();
        }
    }
}