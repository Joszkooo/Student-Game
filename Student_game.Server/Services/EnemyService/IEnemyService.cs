using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.EnemyService
{
    public interface IEnemyService
    {
        Task<ServiceResponse<Enemy>> GetEnemyById(int id);
        Task<ServiceResponse<Enemy>> GetRandomEnemy();
    }
}