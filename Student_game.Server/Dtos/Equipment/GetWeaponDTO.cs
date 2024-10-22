using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Equipment
{
    public class GetWeaponDTO
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HitChance { get; set; }
        public int Cost { get; set; }
        public Rarity Rarity{ get; set; }
        public int Quantity { get; set; }
    }
}