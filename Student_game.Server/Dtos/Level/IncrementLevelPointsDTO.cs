using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Level
{
    public class IncrementLevelPointsDTO
    {
        public int Id { get; set; }
        public int HealthPoints { get; set; }
        
        public int AttackPoints { get; set; }
        
        public int DefensePoints { get; set; }
        
        public int LuckPoints { get; set; }

        public int IntelligencePoints { get; set; }
    }
}