using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Enemie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public Ranks Rank { get; set; }
        
        [Required]
        public int Level { get; set; } = 1;
        
        [Required]
        public int HealthPoints { get; set; } = 100;
        
        [Required]
        public int AttackPoints { get; set; } = 100;
        
        [Required]
        public int DefensePoints { get; set; } = 100;
        
        [Required]
        public int LuckPoints { get; set; } = 100;
        
        [Required]
        public Weapon? Weapon { get; set; }
        
        [Required]
        public Armour? Armour { get; set; }
    }
}