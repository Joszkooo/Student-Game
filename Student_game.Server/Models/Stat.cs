using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_game.Server.Models
{
    public class Stat
    {
        public int Id { get; set;}

        // Stats added during gameplay
        [Required]
        public int Fights { get; set; } = 0;
        
        [Required]
        public int Victories { get; set; } = 0;
        
        [Required]
        public int Defeats { get; set; } = 0;

        [ForeignKey("Student")]
        public int StudentId { get; set;}

        // Database relation
        public Student Student{ get; set; } = null!;
    }
}