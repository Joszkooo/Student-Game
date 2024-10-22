using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace Student_game.Server.Services.LevelService
{
    public class LevelService : ILevelService
    {
        private readonly DataContext _context;

        public LevelService(DataContext context)
        {
            _context = context;
        }

        // funkcja do sprawdzenia czy po np walce jest mozliwy lvl up,
        // jesli odpowiednie xp jest osiagniete oraz maksymalny poziom NIE jest osiagniety,
        // mozna przystapic do inkrementacji danych
        public async Task<ServiceResponse<CheckIfLevelUpDTO>> CheckIfLevelUp(int studentId)
        {
            var serviceResponse = new ServiceResponse<CheckIfLevelUpDTO>();
            try
            {
                var dbStudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId);
                if (dbStudent is not null)
                {
                    if(dbStudent.Experience >= 100 & dbStudent.Rank != Ranks.The_Global_Elite)
                    {
                        dbStudent.LevelPoints += 1;
                        dbStudent.Level += 1;
                        dbStudent.Experience -= 100;
                        dbStudent.Rank += 1;

                        await _context.SaveChangesAsync();
                        serviceResponse.Data = dbStudent.Adapt<CheckIfLevelUpDTO>();
                    }
                    else {
                        serviceResponse.Message = $"Niewystaczająca ilość XP lub maksymalny poziom osiągniety";
                        serviceResponse.Success = false;
                    }
                }
                else
                {
                    serviceResponse.Message = $"Brak studenta w bazie danych";
                    serviceResponse.Success = false;
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

        // funkcja sluzy do lvlowania postaci w zakladce profil (guziczki w prawej dolnej czesci)
        // updateujemy nasza postac zgodnie z przekazana lista 
        // logika listy -> [HP, ATK, DEF, LUCK, INT], zgodnie z liczba na danym miejscu inkrementuyjemy statystyke o wczesniej wspomniania ilosc 
        public async Task<ServiceResponse<IncrementLevelPointsDTO>> IncrementLevelPoints(int studentId, List<int> points)
        {
            var serviceResponse = new ServiceResponse<IncrementLevelPointsDTO>();
            try
            {
                if (points.Count() != 5)
                {
                    serviceResponse.Message = $"Lista nie jest równa 4 ";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                var dbStudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId);

                if (dbStudent is not null)
                {
                    dbStudent.HealthPoints += points[0];
                    dbStudent.AttackPoints += points[1];
                    dbStudent.DefensePoints += points[2];
                    dbStudent.LuckPoints += points[3];
                    dbStudent.IntelligencePoints += points[4];
                    
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = dbStudent.Adapt<IncrementLevelPointsDTO>();
                }
                else
                {
                    serviceResponse.Message = $"Brak studenta w bazie danych";
                    serviceResponse.Success = false;
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