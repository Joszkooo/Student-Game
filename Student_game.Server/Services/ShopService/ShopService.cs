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

        public async Task<ServiceResponse<ItemDTO>> BuyItem(PickItemDTO requestedItem)
        {
            var serviceResponse = new ServiceResponse<ItemDTO>();
            try
            {
                ItemDTO item = new ItemDTO();
                var studentDB = await _context.Students.SingleOrDefaultAsync(s => s.Id == requestedItem.StudentId);
                if (studentDB is null){
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta o Id {requestedItem.StudentId}";
                    return serviceResponse;
                }
                if (requestedItem.Category == CategoryDTO.Armour){
                    var itemDB = await _context.Armours.FirstOrDefaultAsync(x => x.Id == requestedItem.ItemId);
                    if (itemDB is null){
                        serviceResponse.Success=false;
                        serviceResponse.Message= $"Brak przedmiotu o ID {requestedItem.ItemId}";
                        return serviceResponse;
                    }
                    item.Id = itemDB.Id;
                    item.Cost = itemDB.Cost;
                }
                else if (requestedItem.Category == CategoryDTO.Weapon){
                    var itemDB = await _context.Weapons.FirstOrDefaultAsync(x => x.Id == requestedItem.ItemId);
                    if (itemDB is null){
                        serviceResponse.Success=false;
                        serviceResponse.Message= $"Brak przedmiotu o ID {requestedItem.ItemId}";
                        return serviceResponse;
                    }
                    item.Id = itemDB.Id;
                    item.Cost = itemDB.Cost;
                }
                else if (requestedItem.Category == CategoryDTO.Food){
                    var itemDB = await _context.Foods.FirstOrDefaultAsync(x => x.Id == requestedItem.ItemId);
                    if (itemDB is null){
                        serviceResponse.Success=false;
                        serviceResponse.Message= $"Brak przedmiotu o ID {requestedItem.ItemId}";
                        return serviceResponse;
                    }
                    item.Id = itemDB.Id;
                    item.Cost = itemDB.Cost;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przedmiotu o kategorii {requestedItem.Category}";
                    return serviceResponse;
                }
                
                if (item.Id == 0)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przedmiotu w bazie danych, podano ItemId 0";
                    return serviceResponse;
                }
                
                if (studentDB.Money < item.Cost)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak wystarczajacej gotowki do kupna!";
                    return serviceResponse;
                }
                else{
                    studentDB.Money -= item.Cost;
                    if (requestedItem.Category == CategoryDTO.Weapon)
                    {
                        var student_weaponDB = await _context.Student_Weapons
                            .Where(x => x.WeaponId == requestedItem.ItemId && x.StudentId == requestedItem.StudentId).FirstOrDefaultAsync();

                        if (student_weaponDB is not null)
                        {
                            student_weaponDB.Quantity += 1;
                            serviceResponse.Message = $"Pomyslnie dodano kolejna bron ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }else{
                            var weapon = new Student_Weapon{Quantity = 1, StudentId = requestedItem.StudentId, WeaponId=requestedItem.ItemId};
                            _context.Add<Student_Weapon>(weapon);
                            serviceResponse.Message = $"Pomyslnie dodano bron ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }
                        await _context.SaveChangesAsync();
                        return serviceResponse;
                    }
                    else if (requestedItem.Category == CategoryDTO.Food)
                    {
                        var student_foodDB = await _context.Student_Foods
                            .Where(x => x.FoodId == requestedItem.ItemId && x.StudentId == requestedItem.StudentId).FirstOrDefaultAsync();

                        if (student_foodDB is not null)
                        {
                            student_foodDB.Quantity += 1;
                            serviceResponse.Message = $"Pomyslnie dodano kolejne jedzenie ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }else{
                            var food = new Student_Food{Quantity = 1, StudentId = requestedItem.StudentId, FoodId=requestedItem.ItemId};
                            _context.Add<Student_Food>(food);
                            serviceResponse.Message = $"Pomyslnie dodano jedzenie ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }
                        await _context.SaveChangesAsync();
                        return serviceResponse;
                    }
                    else if (requestedItem.Category == CategoryDTO.Armour)
                    {
                        var student_armourDB = await _context.Student_Armors
                            .Where(x => x.ArmourId == requestedItem.ItemId && x.StudentId == requestedItem.StudentId).FirstOrDefaultAsync();

                        if (student_armourDB is not null)
                        {
                            student_armourDB.Quantity += 1;
                            serviceResponse.Message = $"Pomyslnie dodano kolejna zbroje ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }else{
                            var armour = new Student_Armour{Quantity = 1, StudentId = requestedItem.StudentId, ArmourId=requestedItem.ItemId};
                            _context.Add<Student_Armour>(armour);
                            serviceResponse.Message = $"Pomyslnie dodano zbroje ID{requestedItem.ItemId} dla studenta ID {requestedItem.StudentId}";
                        }
                        await _context.SaveChangesAsync();
                        return serviceResponse;
                    }
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

        public async Task<ServiceResponse<Weapon>> SellWeapon(int StudentID, int ItemID)
        {
            var serviceResponse = new ServiceResponse<Weapon>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(x => x.Id == StudentID);
                var weaponDB = await _context.Student_Weapons
                    .Include(x => x.Weapon)
                    .FirstOrDefaultAsync(x => x.WeaponId == ItemID && x.StudentId == StudentID);

                if (weaponDB is null || studentDB is null)
                {
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Brak studenta o ID {StudentID} lub broni w ekwipunku o ID {ItemID}";
                    return serviceResponse;
                }
                if (weaponDB.Quantity > 1){
                    studentDB.Money += (int)Math.Floor((decimal)weaponDB.Weapon.Cost / 2);
                    weaponDB.Quantity -= 1;
                }else{
                    studentDB.Money += (int)Math.Floor((decimal)weaponDB.Weapon.Cost / 2);
                    _context.Attach(weaponDB);
                    _context.Remove(weaponDB);
                }
                await _context.SaveChangesAsync();
                serviceResponse.Message = $"Poprawnie usunieto bron {weaponDB.Weapon.Name} z ekwipunku gracza o ID {StudentID} oraz dodano {weaponDB.Weapon.Cost / 2} gotówki";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Food>> SellFood(int StudentID, int ItemID)
        {
            var serviceResponse = new ServiceResponse<Food>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(x => x.Id == StudentID);
                var foodDB = await _context.Student_Foods
                    .Include(x => x.Food)
                    .FirstOrDefaultAsync(x => x.FoodId == ItemID && x.StudentId == StudentID);

                if (foodDB is null || studentDB is null)
                {
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Brak studenta o ID {StudentID} lub jedzenia w ekwipunku o ID {ItemID}";
                    return serviceResponse;
                }
                if (foodDB.Quantity > 1){
                    studentDB.Money += (int)Math.Floor((decimal)foodDB.Food.Cost / 2);
                    foodDB.Quantity -= 1;
                }else{
                    studentDB.Money += (int)Math.Floor((decimal)foodDB.Food.Cost / 2);
                    _context.Attach(foodDB);
                    _context.Remove(foodDB);
                }
                await _context.SaveChangesAsync();
                serviceResponse.Message = $"Poprawnie usunieto jedzednie {foodDB.Food.Name} z ekwipunku gracza o ID {StudentID} oraz dodano {foodDB.Food.Cost / 2} gotówki";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Armour>> SellArmour(int StudentID, int ItemID)
        {
            var serviceResponse = new ServiceResponse<Armour>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(x => x.Id == StudentID);
                var armourDB = await _context.Student_Armors
                    .Include(x => x.Armour)
                    .FirstOrDefaultAsync(x => x.ArmourId == ItemID && x.StudentId == StudentID);

                if (armourDB is null || studentDB is null)
                {
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Brak studenta o ID {StudentID} lub zbroi w ekwipunku o ID {ItemID}";
                    return serviceResponse;
                }
                if (armourDB.Quantity > 1){
                    studentDB.Money += (int)Math.Floor((decimal)armourDB.Armour.Cost / 2);
                    armourDB.Quantity -= 1;
                }else{
                    studentDB.Money += (int)Math.Floor((decimal)armourDB.Armour.Cost / 2);
                    _context.Attach(armourDB);
                    _context.Remove(armourDB);
                }
                await _context.SaveChangesAsync();
                serviceResponse.Message = $"Poprawnie usunieto zbroje {armourDB.Armour.Name} z ekwipunku gracza o ID {StudentID} oraz dodano {armourDB.Armour.Cost / 2} gotówki";
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