using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Student_Armour
    {
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        [ForeignKey("Armour")]
        public int ArmourId { get; set; }

        // Db relations
        public Student Student{ get; set; } = null!;
        public Armour Armour{ get; set; } = null!;
    }
}