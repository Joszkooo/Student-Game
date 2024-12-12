using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_game.Server.Dtos.Student;


namespace Student_game.Server.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        // GET full info about student 
        public async Task<ServiceResponse<Student>> GetStudentById(int StudentId)
        {
            var serviceResponse = new ServiceResponse<Student>(); 
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == StudentId);
                if (student is not null)
                {
                    serviceResponse.Data = student;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta o {StudentId} id";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
        }

        // GET only armour from student equipment
        public async Task<ServiceResponse<List<GetArmourDTO>>> GetStudentArmour(int StudentId)
        {
            var serviceResponse = new ServiceResponse<List<GetArmourDTO>>();
            try
            {
                var armourDTO = await _context.Student_Armors
                    .Where(x => x.StudentId == StudentId)
                    .Include(x => x.Armour)
                    .Select(x => new GetArmourDTO   // idk how to use Mapster with this DTO so i did it manually 
                    {
                        Id = x.Armour.Id,
                        Name = x.Armour.Name,
                        Defense = x.Armour.Defense,
                        Cost = x.Armour.Cost,
                        Rarity = x.Armour.Rarity,
                        Quantity = x.Quantity
                    })
                    .ToListAsync();
                
                if (armourDTO.Any())
                {
                    serviceResponse.Data = armourDTO;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak zbroi w ekwipunku dla studenta o id:{StudentId} ";
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

        // GET only weapon from student equipment
        public async Task<ServiceResponse<List<GetWeaponDTO>>> GetStudentWeapon(int StudentId)
        {
            var serviceResponse = new ServiceResponse<List<GetWeaponDTO>>();
            try
            {
                var weaponDTO = await _context.Student_Weapons
                    .Where(x => x.StudentId == StudentId)
                    .Include(x => x.Weapon)
                    .Select(x => new GetWeaponDTO   // idk how to use Mapster with this DTO so i did it manually 
                    {
                        Id = x.Weapon.Id,
                        Name = x.Weapon.Name,
                        Damage = x.Weapon.Damage,
                        HitChance = x.Weapon.HitChance,
                        Cost = x.Weapon.Cost,
                        Rarity = x.Weapon.Rarity,
                        Quantity = x.Quantity
                    })
                    .ToListAsync();
                
                if (weaponDTO.Any())
                {
                    serviceResponse.Data = weaponDTO;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak broni w ekwipunku dla studenta o id:{StudentId} ";
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

        // GET only food from student equipment
        public async Task<ServiceResponse<List<GetFoodDTO>>> GetStudentFood(int StudentId)
        {
            var serviceResponse = new ServiceResponse<List<GetFoodDTO>>();
            try
            {
                var foodDTO = await _context.Student_Foods
                    .Where(s => s.StudentId == StudentId)
                    .Include(f => f.Food)
                    .Select(f => new GetFoodDTO     // idk how to use Mapster with this DTO so i did it manually 
                    {
                        Id = f.Food.Id,
                        Name = f.Food.Name,
                        BoostType = f.Food.BoostType,
                        BoostAmount = f.Food.BoostAmount,
                        Duration = f.Food.Duration,
                        Cost = f.Food.Cost,
                        Rarity = f.Food.Rarity,
                        Quantity = f.Quantity
                    })
                    .ToListAsync();
                
                if (foodDTO.Any())
                {
                    serviceResponse.Data = foodDTO;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak jedzenia w ekwipunku dla studenta o id:{StudentId} ";
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

        // GET full equipment of student
        public ServiceResponse<StudentEquipmentDTO> GetStudentEquipment(int StudentId)
        {
            var serviceResponse = new ServiceResponse<StudentEquipmentDTO>();
            try
            {
                var armourList = GetStudentArmour(StudentId).Result.Data;
                var foodList = GetStudentFood(StudentId).Result.Data;
                var weaponList = GetStudentWeapon(StudentId).Result.Data;

                if (!(armourList.Any() && foodList.Any() && weaponList.Any()))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Brak przedmiotów w ewkipunku!";
                    return serviceResponse;
                }

                serviceResponse.Data = new StudentEquipmentDTO
                {
                    Armors = armourList,
                    Foods = foodList,
                    Weapons = weaponList
                };
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }

        // GET student info for Profile page 
        public async Task<ServiceResponse<GetStudentProfileDTO>> GetStudentProfile(int StudentId)
        {
            var serviceResponse = new ServiceResponse<GetStudentProfileDTO>();
            try
            {
                var student = await _context.Students
                    .Include(c => c.Account)
                        .FirstOrDefaultAsync(x => x.Id == StudentId);
                
                if (student is not null)
                {
                    GetStudentProfileDTO response = student.Adapt<GetStudentProfileDTO>(); 
                    response.Nickname = student.Account.Nickname;
                    response.ArmourId = student.ArmourId is null ? null : student.ArmourId;
                    response.WeaponId = student.WeaponId is null ? null : student.WeaponId;
                    
                    serviceResponse.Data = response;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta o {StudentId} id";
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