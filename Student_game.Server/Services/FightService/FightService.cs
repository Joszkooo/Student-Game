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
            int damage = Random.Next(0, attacker.AttackPoints + 1);
            
            if (attacker.Weapon is not null)
            {
                var hitChance = attacker.Weapon.HitChance + (attacker.LuckPoints / 10);
                if (hitChance >= Random.Next(0, 101))
                    damage += attacker.Weapon.Damage;
            }

            damage -= Random.Next(0, opponent.DefensePoints + 1);
            if (opponent.Armour is not null){
                damage -= opponent.Armour.Defense;
            }
            if (damage > 0){
                opponent.HealthPoints -= damage;
                return damage;
            }
            else{
                return 0;
            }
        }

        // set up everything and move other actions to functions
        public async Task<ServiceResponse<FightResultDTO>> FightLocally(FightCharactersDTO characters)
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
                    CharactersDTO player = new CharactersDTO{
                        Name = "Student",
                        HealthPoints = playerDB.HealthPoints,
                        AttackPoints = playerDB.AttackPoints,
                        DefensePoints = playerDB.DefensePoints,
                        LuckPoints = playerDB.LuckPoints,
                        Weapon = playerWeaponDB,
                        Armour = playerArmourDB,
                    };
                    CharactersDTO enemy = new CharactersDTO{
                        Name = enemyDB.Name,
                        HealthPoints = enemyDB.HealthPoints,
                        AttackPoints = enemyDB.AttackPoints,
                        DefensePoints = enemyDB.DefensePoints,
                        LuckPoints = enemyDB.LuckPoints,
                        Weapon = enemyWeaponDB,
                        Armour = enemyArmourDB,
                    };

                    // moving the rest of implementation to Attack function
                    var response = Attack(player, enemy);
                    if (response.Winner.Name == "Student")
                    {
                        response.WinnerExp += Random.Next(0, 101) * RankChecker(enemyDB);
                        response.WinnerGold += Random.Next(0, 101) * RankChecker(enemyDB);
                        playerDB.Money += response.WinnerGold;
                        playerDB.Experience += response.WinnerExp;
                    }
                    
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
        // TODO: Można to uprościć prawdopodobnie przez dodanie T zamiast Student/Enemy
        private async Task LoadPlayerEquipment(Weapon? playerWeaponDB, Armour? playerArmourDB, Student playerDB)
        {
            if (playerDB.WeaponId is not null)
                {playerWeaponDB = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == playerDB.WeaponId);}
            if (playerDB.ArmourId is not null)
                {playerArmourDB = await _context.Armours.FirstOrDefaultAsync(w => w.Id == playerDB.ArmourId);}
        }

        private async Task LoadEnemyEquipment(Weapon? enemyWeaponDB, Armour? enemyArmourDB, Enemy enemyDB)
        {
            if (enemyDB.WeaponId is not null)
                {enemyWeaponDB = await _context.Weapons.FirstOrDefaultAsync(w => w.Id == enemyDB.WeaponId);}
            if (enemyDB.ArmourId is not null)
                {enemyArmourDB = await _context.Armours.FirstOrDefaultAsync(w => w.Id == enemyDB.ArmourId);}
        }

        private int RankChecker(Enemy enemy)
        {
            return enemy.Rank switch
            {
                Ranks.Silver_I or Ranks.Silver_II or Ranks.Silver_III => 1,
                Ranks.Silver_IV or Ranks.Silver_Elite or Ranks.Silver_Elite_Master => 2,
                Ranks.Gold_Nova_I or Ranks.Gold_Nova_II or Ranks.Gold_Nova_III => 3,
                Ranks.Gold_Nova_Master or Ranks.Master_Guardian_I or Ranks.Master_Guardian_II => 4,
                Ranks.Master_Guardian_Elite or Ranks.Distinguished_Master_Guardian or Ranks.Legendary_Eagle => 5,
                Ranks.Legendary_Eagle_Master => 7,
                Ranks.Supreme_Master_First_Class => 8,
                Ranks.The_Global_Elite => 10,
                _ => 0 // Default case
            };
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