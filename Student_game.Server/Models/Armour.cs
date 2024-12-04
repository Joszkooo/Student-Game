using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Armour
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int Defense { get; set; }
        
        [Required]
        public int Cost { get; set; }
        
        [Required]
        public Rarity Rarity{ get; set; }
        
        // Db relation
        public ICollection<Student_Armour> Student_Armours { get; set; } = new List<Student_Armour>();
    }
}