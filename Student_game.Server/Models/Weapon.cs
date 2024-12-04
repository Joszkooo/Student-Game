using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int Damage { get; set; }
        
        [Required]
        public int HitChance { get; set; }
        
        [Required]
        public int Cost { get; set; }
        
        [Required]
        public Rarity Rarity{ get; set; }

        // db relation
        public ICollection<Student_Weapon> Student_Weapons { get; set; } = new List<Student_Weapon>();

    }
}