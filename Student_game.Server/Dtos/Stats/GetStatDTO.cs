using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Stats
{
    public class GetStatDTO
    {
        public int Id { get; set;}

        public string Nickname { get; set;}

        // Stats added during gameplay
        [Required]
        public int Fights { get; set; } = 0;
        
        [Required]
        public int Victories { get; set; } = 0;
        
        [Required]
        public int Defeats { get; set; } = 0;
    }
}