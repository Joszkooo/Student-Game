using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Student
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        

        [Required]
        public int Money { get; set; } = 0;
        
        [Required]
        public int Energy { get; set; } = 100;
        
        [Required]
        public int LevelPoints { get; set; } = 0;
        
        public Ranks Rank { get; set; } = Ranks.Silver_I;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;


        [Required]
        public int HealthPoints { get; set; } = 100;
        
        [Required]
        public int AttackPoints { get; set; } = 1;
        
        [Required]
        public int DefensePoints { get; set; } = 1;
        
        [Required]
        public int LuckPoints { get; set; } = 1;

        [Required]
        public int IntelligencePoints { get; set; } = 1;
    }
}