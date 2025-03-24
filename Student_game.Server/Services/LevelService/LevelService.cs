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


        /* 
        This function must run after every fight.
            Function to monitor if Level Up is available, if so it add's:
                - level points + 1
                - level + 1
                - rank + 1
            and reduces exp by 100
        */
        public async Task<ServiceResponse<CheckIfLevelUpDTO>> CheckIfLevelUp(int studentId)
        {
            var serviceResponse = new ServiceResponse<CheckIfLevelUpDTO>();
            try
            {
                var dbStudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId);
                if (dbStudent is not null)
                {
                    if(dbStudent.Experience >= 100 && dbStudent.Rank != Ranks.The_Global_Elite)
                    {
                        dbStudent.LevelPoints += 1;
                        dbStudent.Level += 1;
                        dbStudent.Experience -= 100;
                        dbStudent.Rank += 1;

                        await _context.SaveChangesAsync();
                        serviceResponse.Data = dbStudent.Adapt<CheckIfLevelUpDTO>();
                        serviceResponse.Message = "Level up!";
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

        /* 
        Function that allow's players to spend their level points.

            If player have enough level points, it will add points where player wanted it in the list:
                - HP
                - ATK
                - DEF
                - LUCK
                - INT
            Then it reduces levelPoints by the sum of it.
        */
        
        /* 
        Funkcja umożliwiająca graczom wydawanie punktów poziomu.
            Jeśli gracz ma wystarczającą ilość punktów poziomu, doda punkty tam, gdzie gracz chciał na liście:
                - HP
                - ATK
                - DEF
                - LUCK
                - INT
            Następnie zmniejsza punkty poziomu o ich sumę.
        */
        public async Task<ServiceResponse<IncrementLevelPointsDTO>> IncrementLevelPoints(int studentId, List<int>? points = null)
        {
            var serviceResponse = new ServiceResponse<IncrementLevelPointsDTO>(); // wrapper naszej odpowiedzi
            try
            {
                var pointsToGive = points ?? [0, 0, 0, 0, 0]; // zmienna z punktami,jeśli zostały podane (czyli nie jest null) to je przypisujemy, w przeciwnym wypadku (jesli jest null) przypisujemy wszędzie 0
                if (pointsToGive.All(o => o == 0)) // jeśli jest wszędzie 0 to kończymy zapytanie i wysyłamy komunikat
                {
                    serviceResponse.Message = $"Lista nie zawiera punktów do przydzielenia";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                var dbStudent = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentId); // łączymy się z bazą danych oraz wyciągamy z niej pierwszego studenta z id podanym w funkcji

                if (dbStudent is not null)
                {
                    var levelPointsSpent = pointsToGive.Sum();
                    if (dbStudent.LevelPoints < levelPointsSpent) { // jeśli nasz student nie ma wystarczająco dużo punktów (czyli sumy z listy) to konczymy zapytanie i wysyłamy komunikat
                        serviceResponse.Message = "Niewystarczajaca ilosc level pointsow do levelowania";
                        serviceResponse.Success = false;
                        return serviceResponse;
                    }
                    // jeśli jednak wszystko jest okej, zaczynamy przypisywanie punktów z mnożnikiem 5 do studenta
                    dbStudent.HealthPoints += pointsToGive[0] * 5;
                    dbStudent.AttackPoints += pointsToGive[1] * 5;
                    dbStudent.DefensePoints += pointsToGive[2] * 5;
                    dbStudent.LuckPoints += pointsToGive[3] * 5;
                    dbStudent.IntelligencePoints += pointsToGive[4] * 5;
                    dbStudent.LevelPoints -= levelPointsSpent; // usuwamy odpowiednio duzo punktów poziomu
                    
                    // jesli jednak wystapiło gdzieś przekroczenie maksymalnej ilości punktów to kończymy zapytanie i wysyłamy komunikat (nie obchodzi nas że przypisaliśmy punkty do studenta bo nie zapisaliśmy tego w bazie danych)
                    if (dbStudent.HealthPoints > 300){
                        serviceResponse.Message = "Punkty zdrowia ponad limit";
                        return serviceResponse;
                    }
                    else if (dbStudent.AttackPoints > 200){
                        serviceResponse.Message = "Punkty ataku ponad limit";
                        return serviceResponse;
                    }
                    else if (dbStudent.DefensePoints > 100){
                        serviceResponse.Message = "Punkty pancerza ponad limit";
                        return serviceResponse;
                    }
                    else if (dbStudent.LuckPoints > 100){
                        serviceResponse.Message = "Punkty szczęścia ponad limit";
                        return serviceResponse;
                    }
                    else if (dbStudent.IntelligencePoints > 100){
                        serviceResponse.Message = "Punkty inteligencji ponad limit";
                        return serviceResponse;
                    }
                    
                    await _context.SaveChangesAsync(); // jeśli wszystko jest okej, zapisujemy dane w bazie danych
                    serviceResponse.Data = dbStudent.Adapt<IncrementLevelPointsDTO>(); // mapujemy naszego studenta do pożądanego typu
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
            return serviceResponse; // zwracamy odpowiedź 
        }
    }
}