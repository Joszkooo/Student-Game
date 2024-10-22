using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Fight
{
    public class AttackResultDTO
    {
        public int Damage { get; set; }
        public int? ActualHitChance { get; set; }
    }
}