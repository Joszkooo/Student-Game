using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.StatService
{
    public interface IStatService
    {
        Task<ServiceResponse<List<GetStatDTO>>> GetAllStats();
        Task<ServiceResponse<GetStatDTO>> GetStatByStudentId(int id);
        Task<ServiceResponse<Stat>> IncrementVictories(int id);
        Task<ServiceResponse<Stat>> IncrementDefeats(int id);
    }
}