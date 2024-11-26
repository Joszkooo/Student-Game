using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Fight
{
    public class FightCharactersDTO
    {
        public int AttackerId { get; set; }
        public int? OpponentId { get; set; }
    }
}