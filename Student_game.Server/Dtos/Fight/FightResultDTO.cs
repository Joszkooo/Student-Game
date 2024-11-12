using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Fight
{
    public class FightResultDTO
    {
        public List<int> EnemyAttacks { get; set; } = new List<int>();
        public List<int> PlayerAttacks { get; set; } = new List<int>();
        public string Winner { get; set; } = string.Empty;
    }
}