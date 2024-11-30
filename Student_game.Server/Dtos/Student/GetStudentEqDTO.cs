using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Student
{
    public class GetStudentEqDTO
    {
        public string Name { get; set; }
        public int Type { get; set; } // Damage / Defense / BoostAmount
        public int Cost { get; set; }
        
        public Boost? BoostType { get; set; } = null; // only if Food
        public int? HitChance { get; set; }  = 0 ;// only if weapon

        public Rarity Rarity { get; set; }
        public int Quantity { get; set; }
    }
}