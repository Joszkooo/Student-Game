using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace Student_game.Server.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _context;

        public FightService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<AttackResultDTO>> SpecificEnemyAttack(int EnemyId)
        {
            var serviceResponse = new ServiceResponse<AttackResultDTO>();
            try
            {
                var dbEnemy = await _context.Enemies.FirstOrDefaultAsync(s => s.Id == EnemyId);
                if (dbEnemy is not null)
                {
                    var damage = 0;
                    damage += dbEnemy.AttackPoints;
                    damage += WeaponAttack(dbEnemy.Weapon.Id, EnemyId).Adapt<AttackResultDTO>().Damage;
                    serviceResponse.Data = damage.Adapt<AttackResultDTO>();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak wroga w bazie danych";
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

        // starts new fight, picks opponent and sets up everything idk REPAIR IT
        public async Task<ServiceResponse<FightResultDTO>> Fight()
        {
            throw new NotImplementedException();
            // var serviceResponse = new ServiceResponse<FightResultDTO>();
            // try
            // {
            //     // var dbStudent = _context.Students
            //     var dbEnemy = _context.Enemies.FirstOrDefaultAsync(e => e.Id == new Random().Next(0, ));
            // }
            // catch (Exception ex)
            // {
            //     serviceResponse.Success = false;
            //     serviceResponse.Message = $"Error: {ex.Message}";
            //     return serviceResponse;
            // }
        }

        // full attack to deal 
        public async Task<ServiceResponse<AttackResultDTO>> PlayerAttack(int PlayerId)
        {
            var serviceResponse = new ServiceResponse<AttackResultDTO>();
            try
            {
                var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == PlayerId);
                if (dbStudent is not null)
                {
                    var damage = 0;
                    damage += dbStudent.AttackPoints;
                    damage += WeaponAttack(dbStudent.Weapon.Id, PlayerId).Adapt<AttackResultDTO>().Damage;
                    serviceResponse.Data = damage.Adapt<AttackResultDTO>();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta w bazie danych";
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
        

        // only weapon attack to deal
        public async Task<ServiceResponse<AttackResultDTO>> WeaponAttack(int WeaponId, int StudentId)
        {
            var serviceResponse = new ServiceResponse<AttackResultDTO>();
            try
            {
                var dbWeapon =  await _context.Weapons.FirstOrDefaultAsync(w => w.Id == WeaponId);
                var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == StudentId);
                if (dbWeapon is not null && dbStudent is not null)
                {
                    var chance = new Random().Next(100) + dbStudent.LuckPoints;

                    // udalo sie trafic 
                    if (chance >= dbWeapon.HitChance){
                        var result =  dbWeapon.Adapt<AttackResultDTO>();

                        result.ActualHitChance = chance;
                        serviceResponse.Data = result;
                    }
                    else{
                        serviceResponse.Message = $"Pudło! Wyrzuciłeś {chance}% na trafienie! \n Potrzebowales {dbWeapon.HitChance}%";
                    }
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak broni {WeaponId} lub studenta {StudentId} w bazie danych";
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

        public Task<ServiceResponse<AttackResultDTO>> RandomEnemyAttack(Enemy enemy)
        {
            return PlayerAttack(enemy.Id);
        }
    }
}