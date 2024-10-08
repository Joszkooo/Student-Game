using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FightService
{
    public class FightService : IFightService
    {
        public Task<ServiceResponse<FightResultDTO>> Fight()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AttackResultDTO>> GetHighScore()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AttackResultDTO>> SkillAttack()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AttackResultDTO>> WeaponAttack()
        {
            throw new NotImplementedException();
        }
    }
}