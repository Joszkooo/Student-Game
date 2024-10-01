using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Student_Weapon
    {
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        [ForeignKey("Weapon")]
        public int WeaponId { get; set; }
    }
}