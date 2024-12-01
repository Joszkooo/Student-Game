using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Fight
{
    public class CharactersDTO
    {
        public string? Name { get; set; }
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public int LuckPoints { get; set; }
        public Weapon? Weapon { get; set; }
        public Armour? Armour { get; set;}

    }
}