using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDTO>> WeaponAttack();
        Task<ServiceResponse<AttackResultDTO>> SkillAttack();
        Task<ServiceResponse<FightResultDTO>> Fight();
        Task<ServiceResponse<AttackResultDTO>> GetHighScore();

    }
}