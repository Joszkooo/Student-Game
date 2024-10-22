using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDTO>> WeaponAttack(int WeaponId, int StudentId);
        Task<ServiceResponse<AttackResultDTO>> PlayerAttack(int PlayerId);
        Task<ServiceResponse<AttackResultDTO>> SpecificEnemyAttack(int EnemyId);
        Task<ServiceResponse<AttackResultDTO>> RandomEnemyAttack(Enemy enemy);
        Task<ServiceResponse<FightResultDTO>> Fight();

    }
}