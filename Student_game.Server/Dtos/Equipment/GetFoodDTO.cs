using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Equipment
{
    public class GetFoodDTO
    {
        public string Name { get; set; }
        public Boost BoostType { get; set; }
        public int BoostAmount { get; set; }
        public int Duration { get; set; }
        public Rarity Rarity{ get; set; }
        public int Quantity { get; set; }
    }
}