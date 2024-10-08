using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Student
{
    public class GetStudentProfileDTO
    {
        public int Id { get; set; }
        
        public int HealthPoints { get; set; } = 100;
        
        public int AttackPoints { get; set; } = 1;
        
        public int DefensePoints { get; set; } = 1;
        
    }
}