using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Student
{
    public class GetStudentProfileDTO
    {   
        public string Nickname { get; set;} = string.Empty;
        public int Money { get; set; } = 0;
        public int Energy { get; set; } = 100;
        public Ranks Rank { get; set; } = Ranks.Silver_I;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int LevelPoints { get; set; } = 0;
        public int HealthPoints { get; set; } = 100;
        public int AttackPoints { get; set; } = 1;
        public int DefensePoints { get; set; } = 1;
        public int LuckPoints { get; set; } = 1;
        public int IntelligencePoints { get; set; } = 1;
        public int? WeaponId { get; set; } = 0;
        public int? ArmourId { get; set; } = 0;
    }
}