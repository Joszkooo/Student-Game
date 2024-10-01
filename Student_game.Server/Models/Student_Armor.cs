using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Student_Armor
    {
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        [ForeignKey("Armor")]
        public int ArmorId { get; set; }
    }
}