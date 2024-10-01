using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Student_game.Server.Models
{
    public class Student_Food
    {
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        [ForeignKey("Food")]
        public int FoodId { get; set; }
    }
}