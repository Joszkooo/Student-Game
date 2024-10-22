using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Level
{
    public class CheckIfLevelUpDTO
    {
        public int Id { get; set; }
        public int LevelPoints { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Ranks Rank { get; set; }
    }
}