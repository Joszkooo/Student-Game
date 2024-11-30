using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly DataContext _context;
        public EquipmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Student>> EquipArmour(int StudentId, int ArmourId)
        {
            var serviceResponse = new ServiceResponse<Student>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(s => s.Id == StudentId);
                var want_to_equipArmourDB = await _context.Student_Armors.FirstOrDefaultAsync(a => a.ArmourId == ArmourId && a.StudentId == StudentId);
                var equipped_now_ArmourDB = await _context.Student_Armors.FirstOrDefaultAsync(a => a.ArmourId == studentDB.ArmourId && a.StudentId == StudentId);
                
                if(studentDB is not null && want_to_equipArmourDB is not null && equipped_now_ArmourDB is not null){
                    if (studentDB.ArmourId == ArmourId){ // check if armour we want equip is not being equipped now
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Juz nosisz armour o ID {ArmourId}";
                        return serviceResponse;
                    }

                    if (studentDB.ArmourId is not null){
                        if (equipped_now_ArmourDB.Quantity >= 1){
                            equipped_now_ArmourDB.Quantity += 1;
                        }
                        else{
                            // stworz nowy row w db i dodaj tam stary armour
                            var old_armour = new Student_Armour{
                                Quantity = 1,
                                StudentId = StudentId,
                                ArmourId = studentDB.ArmourId.Value
                            };
                            await _context.Student_Armors.AddAsync(old_armour);
                        }
                    }
                    if (want_to_equipArmourDB.Quantity > 1){
                        want_to_equipArmourDB.Quantity -= 1;
                    }
                    else{
                        // usun armour z student_armour
                        _context.Student_Armors.Attach(want_to_equipArmourDB);
                        _context.Student_Armors.Remove(want_to_equipArmourDB);
                    }
                    studentDB.ArmourId = ArmourId;
                    await _context.SaveChangesAsync();
                }else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak Studenta/Armora/Armora w eq studenta o id {StudentId/ArmourId}";
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

        public async Task<ServiceResponse<Student>> EquipWeapon(int StudentId, int WeaponId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Student>> UseFood(int StudentId, int FoodId)
        {
            throw new NotImplementedException();
        }
    }
}