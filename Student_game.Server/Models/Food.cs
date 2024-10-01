using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Food
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public Boost BoostType { get; set; }
        
        [Required]
        public int BoostAmount { get; set; }
        
        [Required]
        public int Duration { get; set; }
    }
}