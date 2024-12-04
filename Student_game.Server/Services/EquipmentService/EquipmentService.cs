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
        public async Task<ServiceResponse<Student>> EquipArmour(GetEquipmentServiceDTO studentItem)
        {
            var serviceResponse = new ServiceResponse<Student>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentItem.StudentID);
                var want_to_equipArmourDB = await _context.Student_Armors.FirstOrDefaultAsync(a => a.ArmourId == studentItem.ItemID && a.StudentId == studentItem.StudentID);
                var equipped_now_ArmourDB = await _context.Student_Armors.FirstOrDefaultAsync(a => a.ArmourId == studentDB.ArmourId && a.StudentId == studentItem.StudentID);
                
                if(studentDB is not null && want_to_equipArmourDB is not null){
                    if (studentDB.ArmourId == studentItem.ItemID){ // check if armour we want equip is not being equipped now
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Juz nosisz armour o ID {studentItem.ItemID}";
                        return serviceResponse;
                    }

                    if (studentDB.ArmourId is not null){
                        if (equipped_now_ArmourDB is null){
                            // stworz nowy row w db i dodaj tam stary armour
                            var old_armour = new Student_Armour{
                                Quantity = 1,
                                StudentId = studentItem.StudentID,
                                ArmourId = studentDB.ArmourId.Value
                            };
                            await _context.Student_Armors.AddAsync(old_armour);
                            
                            serviceResponse.Message += $"Dodano obecnie noszony do bazy danych. ";
                        }
                        else{
                            equipped_now_ArmourDB.Quantity += 1;
                            serviceResponse.Message += $"Dodano 1 do quantity w obecnie noszonym. ";
                        }
                    }
                    if (want_to_equipArmourDB.Quantity > 1){
                        want_to_equipArmourDB.Quantity -= 1;
                        serviceResponse.Message += $"Usunieto 1 do quantity w zakladanym przedmiocie. ";
                    }
                    else{
                        // usun armour z student_armour
                        _context.Student_Armors.Attach(want_to_equipArmourDB);
                        _context.Student_Armors.Remove(want_to_equipArmourDB);
                        
                        serviceResponse.Message += $"Usunieto zakladny przedmiot z bazy danych ";
                    }
                    studentDB.ArmourId = studentItem.ItemID;
                    serviceResponse.Message += $"Założono Armour {studentItem.ItemID} dla Studenta o id {studentItem.StudentID}";
                    await _context.SaveChangesAsync();
                }else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak Studenta/Armora w eq studenta o id {studentItem.StudentID}/{studentItem.ItemID}";
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

        public async Task<ServiceResponse<Student>> EquipWeapon(GetEquipmentServiceDTO studentItem)
        {
            var serviceResponse = new ServiceResponse<Student>();
            try
            {
                var studentDB = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentItem.StudentID);
                var want_to_equipWeaponDB = await _context.Student_Weapons.FirstOrDefaultAsync(a => a.WeaponId == studentItem.ItemID && a.StudentId == studentItem.StudentID);
                var equipped_now_WeaponDB = await _context.Student_Weapons.FirstOrDefaultAsync(a => a.WeaponId == studentDB.WeaponId && a.StudentId == studentItem.StudentID);
                
                if(studentDB is not null && want_to_equipWeaponDB is not null){
                    if (studentDB.WeaponId == studentItem.ItemID){ // check if weapon we want equip is not being equipped now
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Juz nosisz bron o ID {studentItem.ItemID}";
                        return serviceResponse;
                    }

                    if (studentDB.WeaponId is not null){
                        if (equipped_now_WeaponDB is null){
                            // stworz nowy row w db i dodaj tam stary weapon
                            var old_weapon = new Student_Weapon{
                                Quantity = 1,
                                StudentId = studentItem.StudentID,
                                WeaponId = studentDB.WeaponId.Value
                            };
                            await _context.Student_Weapons.AddAsync(old_weapon);
                            
                            serviceResponse.Message += $"Dodano obecnie noszony do bazy danych. ";
                        }
                        else{
                            equipped_now_WeaponDB.Quantity += 1;
                            serviceResponse.Message += $"Dodano 1 do quantity w obecnie noszonym. ";
                        }
                    }
                    if (want_to_equipWeaponDB.Quantity > 1){
                        want_to_equipWeaponDB.Quantity -= 1;
                        serviceResponse.Message += $"Usunieto 1 do quantity w zakladanym przedmiocie. ";
                    }
                    else{
                        // usun armour z student_armour
                        _context.Student_Weapons.Attach(want_to_equipWeaponDB);
                        _context.Student_Weapons.Remove(want_to_equipWeaponDB);
                        
                        serviceResponse.Message += $"Usunieto zakladny przedmiot z bazy danych ";
                    }
                    studentDB.WeaponId = studentItem.ItemID;
                    serviceResponse.Message += $"Założono bron {studentItem.ItemID} dla Studenta o id {studentItem.StudentID}";
                    await _context.SaveChangesAsync();
                }else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak Studenta/Broni w eq studenta o id {studentItem.StudentID}/{studentItem.ItemID}";
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
    }
}