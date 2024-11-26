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
        private static readonly Random Random = new();
        public FightService(DataContext context, IEnemyService enemyService)
        {
            _context = context;
            _enemyService = enemyService;
        }


        /* 
        Function to make attacks:
            - it's calculate damage, including weapon and enemy armour
            - it's decreasing hp to opponent
            
            returning damage dealt to opponent  
        */
        private static int doAttack(CharactersDTO attacker, CharactersDTO opponent)
        {
            // student stats
            int damage = Random.Next(attacker.AttackPoints);
            
            if (attacker.Weapon is not null)
            {
                var hitChance = attacker.Weapon.HitChance + (attacker.LuckPoints / 10);
                if (hitChance >= Random.Next(101))
                    damage += attacker.Weapon.Damage;
            }

            damage -= Random.Next(opponent.DefensePoints);
            if (opponent.Armour is not null)
                damage -= opponent.Armour.Defense;
            
            if (damage > 0)
                opponent.HealthPoints -= damage;
            
            return damage;
        }

        // set up everything and move other actions to functions
        public async Task<ServiceResponse<FightResultDTO>> FightLocaly(FightCharactersDTO characters)
        {
            var serviceResponse = new ServiceResponse<FightResultDTO>();
            try
            {
                // variables used in if statements
                Weapon? playerWeaponDB = null;
                Armour? playerArmourDB = null;

                Weapon? enemyWeaponDB = null;
                Armour? enemyArmourDB = null;

                // we are deciding if we want random enemy or specific one
                var enemyDB = characters.OpponentId is null 
                    ? (await _enemyService.GetRandomEnemy()).Data 
                    : await _context.Enemies.FirstOrDefaultAsync(x => x.Id == characters.OpponentId);
                
                // player (student) must be declared
                var playerDB = await _context.Students.FirstOrDefaultAsync(x => x.Id == characters.AttackerId);

                if (enemyDB is null || playerDB is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak przecwinika lub gracza o ID {characters.OpponentId}/{characters.AttackerId}";
                    return serviceResponse;
                }
                
                    // if player (student) have weapon/armour, load it
                    await LoadPlayerEquipment(playerWeaponDB, playerArmourDB, playerDB);
                    // if enemy have weapon/armour, load it
                    await LoadEnemyEquipment(enemyWeaponDB, enemyArmourDB, enemyDB);

                    // transforming player and enemy from db into only data we need 
                    var player = playerDB.Adapt<CharactersDTO>();
                    var enemy = enemyDB.Adapt<CharactersDTO>();

                    // moving the rest of implementation to AttackLocaly function
                    var response = Attack(player, enemy);
        
                    playerDB.HealthPoints = player.HealthPoints;
                    enemyDB.HealthPoints = enemy.HealthPoints;        
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = response;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }

        private async Task LoadPlayerEquipment(Weapon? playerWeaponDB, Armour? playerArmourDB, Student playerDB)
        {
            if (playerDB.EqWeaponId is not null)
                {playerWeaponDB = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == playerDB.EqWeaponId);}
            if (playerDB.EqArmourId is not null)
                {playerArmourDB = await _context.Armours.FirstOrDefaultAsync(w => w.Id == playerDB.EqArmourId);}
        }

        private async Task LoadEnemyEquipment(Weapon? enemyWeaponDB, Armour? enemyArmourDB, Enemy enemyDB)
        {
            if (enemyDB.WeaponId is not null)
                {enemyWeaponDB = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == enemyDB.WeaponId);}
            if (enemyDB.ArmourId is not null)
                {enemyArmourDB = await _context.Armours.FirstOrDefaultAsync(w => w.Id == enemyDB.ArmourId);}
        }

        private FightResultDTO Attack(CharactersDTO attacker, CharactersDTO opponent)
        {
            var results = new FightResultDTO();
                while(true)
                {
                    // student turn
                    results.AttackerAttacks.Add(doAttack(attacker, opponent));

                    if ( opponent.HealthPoints <= 0 )
                    {
                        results.Winner = attacker;
                        results.Looser = opponent;
                        break;
                    }

                    // enemy turn
                    results.OpponentAttacks.Add(doAttack(opponent, attacker));
                    if ( attacker.HealthPoints <= 0 )
                    {
                        results.Winner = opponent;
                        results.Looser = attacker;
                        break;
                    }
                }
                return results;
        }

        public Task<ServiceResponse<FightResultDTO>> FightOnline(FightCharactersDTO characters)
        {
            throw new NotImplementedException();
        }
    }
}