using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.LevelService
{
    public interface ILevelService
    {
        Task<ServiceResponse<IncrementLevelPointsDTO>> IncrementLevelPoints(int studentId, List<int> points);
        Task<ServiceResponse<CheckIfLevelUpDTO>> CheckIfLevelUp(int studentId);
    }
}