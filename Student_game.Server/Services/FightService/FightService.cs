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
        private readonly IEnemyService _enemyService;
        public FightService(DataContext context, IEnemyService enemyService)
        {
            _context = context;
            _enemyService = enemyService;
        }

        public async Task<ServiceResponse<AttackResultDTO>> EnemyAttack(int EnemyId)
        {
            var serviceResponse = new ServiceResponse<AttackResultDTO>();
            try
            {
                var enemyDB = await _context.Enemies.FirstOrDefaultAsync(x => x.Id == EnemyId);
                if (enemyDB is not null)
                {
                    var attack = enemyDB.AttackPoints;
                    var luck = enemyDB.LuckPoints;
                    var weaponHitChance = enemyDB.Weapon.HitChance;
                    var weaponAttack = enemyDB.Weapon.Damage;
                    
                    var totalDMG = attack + weaponAttack;
                    var totalHitChance = (luck + weaponHitChance) / 100;

                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przecwinika w bazie danych o id {EnemyId}";
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
        public async Task<ServiceResponse<FightResultDTO>> Fight(int student)
        {
            var serviceResponse = new ServiceResponse<FightResultDTO>();
            try
            {
                var randomEnemy = _enemyService.GetRandomEnemy().Result.Data;
                if (randomEnemy is not null)
                {
                    do
                    {
                        // student turn
                        
                        // enemy turn

                    } while (randomEnemy.HealthPoints <= 0 || randomEnemy.HealthPoints <= 0);
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak losowego przeciwnika";
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

        // full attack to deal 
        public async Task<ServiceResponse<AttackResultDTO>> PlayerAttack(int PlayerId)
        {
            var serviceResponse = new ServiceResponse<AttackResultDTO>();
            try
            {
                
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