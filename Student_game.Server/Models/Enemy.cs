using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        // For appearance during the game
        [Required]
        public Ranks Rank { get; set; }
        
        [Required]
        public int Level { get; set; } = new Random().Next(11);
        
        // Stas (should be pseudo random in the game)
        [Required]
        public int HealthPoints { get; set; } = new Random().Next(101);
        
        [Required]
        public int AttackPoints { get; set; } = new Random().Next(101);
        
        [Required]
        public int DefensePoints { get; set; } = new Random().Next(101);
        
        [Required]
        public int LuckPoints { get; set; } = new Random().Next(101);


        [ForeignKey("Weapon")]
        public int WeaponId { get; set; }
        
        [ForeignKey("Armor")]
        public int ArmourId { get; set;}
        
        // Db relation
        [Required]
        public Weapon Weapon { get; set; } = null!;
        
        [Required]
        public Armour Armour { get; set; } = null!;
    }
}